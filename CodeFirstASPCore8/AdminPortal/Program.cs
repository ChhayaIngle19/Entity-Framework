using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.EntityFrameworkCore;
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
                    Console.WriteLine("Which table do you want to upload? (Country, StateProvince)");
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

        // Handles table uploads
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
                    await SeedCountriesAsync(context, filePath);
                    break;
                case "stateprovince":
                    await SeedStatesAsync(context, filePath);
                    break;
                default:
                    Console.WriteLine("Invalid table name!");
                    break;
            }
        }

        // ✅ Inserts Country data first
        static async Task SeedCountriesAsync(AdminPortalDbContext context, string filePath)
        {
            try
            {
                using var reader = new StreamReader(filePath);
                using var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    MissingFieldFound = null,
                    HeaderValidated = null,
                    IgnoreBlankLines = true,
                    Delimiter = ","
                });

                var records = csv.GetRecords<Country>().ToList();

                // ✅ Insert country data (Avoids duplicate tracking issues)
                await context.Country.AddRangeAsync(records);
                await context.SaveChangesAsync();

                Console.WriteLine($"Country data seeded successfully! Total records inserted: {records.Count}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading Country CSV file: {ex.Message}");
            }
        }

        // ✅ Inserts StateProvince data while ensuring `Country` exists
        static async Task SeedStatesAsync(AdminPortalDbContext context, string filePath)
        {
            try
            {
                using var reader = new StreamReader(filePath);
                using var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    MissingFieldFound = null,
                    HeaderValidated = null,
                    IgnoreBlankLines = true,
                    Delimiter = ","
                });

                var csvRecords = csv.GetRecords<StateProvince>().ToList();
                var states = new List<StateProvince>();

                foreach (var record in csvRecords)
                {
                    // ✅ Check if the Country already exists in the DbContext or Database
                    var country = await context.Country.FirstOrDefaultAsync(c => c.CountryId == record.CountryId);

                    if (country == null)
                    {
                        // ✅ If country doesn't exist, create a new one
                        country = new Country { CountryId = record.CountryId, Name = "Unknown", Abbr = "UNK" }; // "Unknown" in case name is missing
                        await context.Country.AddAsync(country);
                        await context.SaveChangesAsync();
                    }

                    var stateProvince = new StateProvince
                    {
                        Name = record.Name,
                        Abbr = record.Abbr,
                        CountryId = record.CountryId,
                        Country = country // ✅ Correct: Uses the existing `Country` instance
                    };

                    states.Add(stateProvince);
                }

                // ✅ Insert valid states
                if (states.Any())
                {
                    await context.StateProvince.AddRangeAsync(states);
                    await context.SaveChangesAsync();
                    Console.WriteLine($"StateProvince data seeded successfully! Total records inserted: {states.Count}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading StateProvince CSV file: {ex.Message}");
            }
        }
    }
}
