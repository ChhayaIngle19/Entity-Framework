using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AdminPortal.Data;
using AdminPortal.Models;

namespace AdminPortal
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var configuration = services.GetRequiredService<IConfiguration>();

                try
                {
                    var context = services.GetRequiredService<AdminPortalDbContext>();

                    // Apply pending migrations
                    await context.Database.MigrateAsync();

                    // Ask the user which table they want to upload
                    Console.WriteLine("Which table do you want to upload? (Country, StateProvince, PersonName, Employee, HCP, Region, Hospital, Address)");
                    string? tableName = Console.ReadLine()?.Trim();

                    // Get file path from appsettings.json
                    string filePath = configuration[$"DataSeeding:{tableName}"];

                    if (!string.IsNullOrEmpty(filePath))
                    {
                        await UploadFileAsync(context, tableName, filePath);
                    }
                    else
                    {
                        Console.WriteLine("Invalid table name or file path not found!");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred while migrating or seeding the database: {ex.Message}");
                }
            }

            await host.RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, config) =>
                {
                    config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                })
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddDbContext<AdminPortalDbContext>(options =>
                        options.UseSqlServer("Server=DESKTOP-U58E1DM\\SQLEXPRESS;Database=AdminPortal;Trusted_Connection=True;Encrypt=False;"));

                    services.AddSingleton<IConfiguration>(provider =>
                    {
                        var configBuilder = new ConfigurationBuilder()
                            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                            .Build();
                        return configBuilder;
                    });
                });

        // Generic method to upload CSV data
        static async Task UploadFileAsync(AdminPortalDbContext context, string tableName, string filePath)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"{tableName} file not found!");
                return;
            }

            switch (tableName.ToLower())
            {
                case "country":
                    await SeedTableAsync<Country>(context.Country, filePath, context);
                    break;
                case "stateprovince":
                    await SeedTableAsync<StateProvince>(context.StateProvince, filePath, context);
                    break;
                //case "personname":
                //    await SeedTableAsync<PersonName>(context.PersonName, filePath, context);
                //    break;
                //case "employee":
                //    await SeedTableAsync<Employee>(context.Employee, filePath, context);
                //    break;
                //case "hcp":
                //    await SeedTableAsync<HCP>(context.HCP, filePath, context);
                //    break;
                //case "region":
                //    await SeedTableAsync<Region>(context.Region, filePath, context);
                //    break;
                //case "hospital":
                //    await SeedTableAsync<Hospital>(context.Hospital, filePath, context);
                //    break;
                //case "address":
                //    await SeedTableAsync<Address>(context.Address, filePath, context);
                //    break;
                default:
                    Console.WriteLine("Invalid table name!");
                    break;
            }
        }

        // Generic method for inserting data from CSV
        static async Task SeedTableAsync<T>(DbSet<T> dbSet, string filePath, AdminPortalDbContext context) where T : class
{
    try
    {
        using var reader = new StreamReader(filePath);
        using var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            MissingFieldFound = null,
            HeaderValidated = null, // Ignore header validation
            IgnoreBlankLines = true,
            Delimiter = ","
        });

        csv.Context.TypeConverterOptionsCache.GetOptions<long?>().NullValues.Add(string.Empty);

        var records = new List<T>();
        int batchSize = 1000;
        int totalRecords = 0;

        while (csv.Read())
        {
            try
            {
                var record = csv.GetRecord<T>();

                // Handle foreign key mapping for StateProvince
                if (record is StateProvince state)
                {
                    var country = await context.Country.FirstOrDefaultAsync(c => c.Id == state.CountryId);
                    if (country == null)
                    {
                        Console.WriteLine($"Skipping row {csv.Parser.Row}: Invalid CountryId {state.CountryId}");
                        continue;
                    }
                }

                records.Add(record);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error parsing CSV row at line {csv.Parser.Row}: {ex.Message}");
                continue;
            }

            if (records.Count >= batchSize)
            {
                await dbSet.AddRangeAsync(records);
                await context.SaveChangesAsync();
                totalRecords += records.Count;
                records.Clear();
            }
        }

        if (records.Count > 0)
        {
            await dbSet.AddRangeAsync(records);
            await context.SaveChangesAsync();
            totalRecords += records.Count;
        }

        Console.WriteLine($"{typeof(T).Name} data seeded successfully! Total records inserted: {totalRecords}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error reading CSV file: {ex.Message}");
    }
   
        }

    }

}
