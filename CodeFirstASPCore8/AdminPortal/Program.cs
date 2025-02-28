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
                // Uncomment and add cases for other tables if needed
                // case "stateprovince":
                //     await SeedTableAsync<StateProvince>(context.StateProvince, filePath, context);
                //     break;
                // case "personname":
                //     await SeedTableAsync<PersonName>(context.PersonName, filePath, context);
                //     break;
                // case "employee":
                //     await SeedTableAsync<Employee>(context.Employee, filePath, context);
                //     break;
                // case "hcp":
                //     await SeedTableAsync<HCP>(context.HCP, filePath, context);
                //     break;
                // case "region":
                //     await SeedTableAsync<Region>(context.Region, filePath, context);
                //     break;
                // case "hospital":
                //     await SeedTableAsync<Hospital>(context.Hospital, filePath, context);
                //     break;
                // case "address":
                //     await SeedTableAsync<Address>(context.Address, filePath, context);
                //     break;
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
                    Delimiter = "," // Ensure correct delimiter
                });

                // Allow empty Id values for auto-generated columns
                csv.Context.TypeConverterOptionsCache.GetOptions<long?>().NullValues.Add(string.Empty);

                var records = new List<T>();
                int batchSize = 1000;
                int totalRecords = 0;

                while (csv.Read())
                {
                    try
                    {
                        var record = csv.GetRecord<T>();
                        records.Add(record);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error parsing CSV row: {ex.Message}");
                        continue; // Skip problematic row and continue processing
                    }

                    if (records.Count >= batchSize)
                    {
                        await InsertDataAsync(dbSet, context, records);
                        totalRecords += records.Count;
                        records.Clear();
                    }
                }

                if (records.Count > 0)
                {
                    await InsertDataAsync(dbSet, context, records);
                    totalRecords += records.Count;
                }

                Console.WriteLine($"{typeof(T).Name} data seeded successfully! Total records inserted: {totalRecords}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading CSV file: {ex.Message}");
            }
        }

        // Handles inserting data while considering IDENTITY_INSERT for identity columns
        private static async Task InsertDataAsync<T>(DbSet<T> dbSet, AdminPortalDbContext context, List<T> records) where T : class
        {
            var entityType = context.Model.FindEntityType(typeof(T));
            var tableName = entityType.GetTableName();

            // Check if the table has an identity column
            bool hasIdentityColumn = entityType.FindPrimaryKey().Properties.Any(p => p.ValueGenerated == ValueGenerated.OnAdd);

            try
            {
                if (hasIdentityColumn)
                {
                    await context.Database.ExecuteSqlRawAsync($"SET IDENTITY_INSERT {tableName} ON");
                }

                await dbSet.AddRangeAsync(records);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inserting data into {tableName}: {ex.Message}");
            }
            finally
            {
                if (hasIdentityColumn)
                {
                    await context.Database.ExecuteSqlRawAsync($"SET IDENTITY_INSERT {tableName} OFF");
                }
            }
        }
    }
}









//using System;
//using System.Threading.Tasks;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Hosting;
//using Microsoft.Extensions.Configuration;
//using AdminPortal.Data;
//using System.IO;
//using CsvHelper;
//using System.Globalization;
//using System.Linq;
//using CsvHelper.Configuration;
//using AdminPortal.Models;


//namespace AdminPortal
//{
//    class Program
//    {
//        static async Task Main(string[] args)
//        {
//            var host = CreateHostBuilder(args).Build();

//            using (var scope = host.Services.CreateScope())
//            {
//                var services = scope.ServiceProvider;
//                var configuration = services.GetRequiredService<IConfiguration>();

//                try
//                {
//                    var context = services.GetRequiredService<AdminPortalDbContext>();

//                    // Apply pending migrations
//                    await context.Database.MigrateAsync();

//                    // Ask the user which table they want to upload
//                    Console.WriteLine("Which table do you want to upload? (Country, StateProvince, PersonName, Employee, HCP, Region, Hospital, Address)");
//                    string? tableName = Console.ReadLine()?.Trim();

//                    // Get file path from appsettings.json
//                    string filePath = configuration[$"DataSeeding:{tableName}"];

//                    if (!string.IsNullOrEmpty(filePath))
//                    {
//                        await UploadFileAsync(context, tableName, filePath);
//                    }
//                    else
//                    {
//                        Console.WriteLine("Invalid table name or file path not found!");
//                    }
//                }
//                catch (Exception ex)
//                {
//                    Console.WriteLine($"An error occurred while migrating or seeding the database: {ex.Message}");
//                }
//            }

//            await host.RunAsync();
//        }

//        public static IHostBuilder CreateHostBuilder(string[] args) =>
//            Host.CreateDefaultBuilder(args)
//                .ConfigureAppConfiguration((context, config) =>
//                {
//                    config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
//                })
//                .ConfigureServices((hostContext, services) =>
//                {
//                    services.AddDbContext<AdminPortalDbContext>(options =>
//                        options.UseSqlServer("Server=DESKTOP-U58E1DM\\SQLEXPRESS;Database=AdminPortal;Trusted_Connection=True;Encrypt=False;"));

//                    services.AddSingleton<IConfiguration>(provider =>
//                    {
//                        var configBuilder = new ConfigurationBuilder()
//                            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
//                            .Build();
//                        return configBuilder;
//                    });
//                });

//        // Generic method to upload CSV data
//        static async Task UploadFileAsync(AdminPortalDbContext context, string tableName, string filePath)
//        {
//            if (!File.Exists(filePath))
//            {
//                Console.WriteLine($"{tableName} file not found!");
//                return;
//            }

//            switch (tableName.ToLower())
//            {
//                case "country":
//                    await SeedTableAsync<Country>(context.Country, filePath, context);
//                    break;
//                //case "stateprovince":
//                //    await SeedTableAsync<StateProvince>(context.StateProvince, filePath, context);
//                //    break;
//                //case "personname":
//                //    await SeedTableAsync<PersonName>(context.PersonName, filePath, context);
//                //    break;
//                //case "employee":
//                //    await SeedTableAsync<Employee>(context.Employee, filePath, context);
//                //    break;
//                //case "hcp":
//                //    await SeedTableAsync<HCP>(context.HCP, filePath, context);
//                //    break;
//                //case "region":
//                //    await SeedTableAsync<Region>(context.Region, filePath, context);
//                //    break;
//                //case "hospital":
//                //    await SeedTableAsync<Hospital>(context.Hospital, filePath, context);
//                //    break;
//                //case "address":
//                //    await SeedTableAsync<Address>(context.Address, filePath, context);
//                //    break;
//                default:
//                    Console.WriteLine("Invalid table name!");
//                    break;
//            }
//        }

//        // Generic method for inserting data from CSV
//        static async Task SeedTableAsync<T>(DbSet<T> dbSet, string filePath, AdminPortalDbContext context) where T : class
//        {
//            var batchSize = 1000;
//            using var reader = new StreamReader(filePath);
//            using var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
//            {
//                MissingFieldFound = null
//            });

//            var records = new List<T>();
//            while (csv.Read())
//            {
//                var record = csv.GetRecord<T>();
//                records.Add(record);

//                if (records.Count >= batchSize)
//                {
//                    await dbSet.AddRangeAsync(records);
//                    await context.SaveChangesAsync();
//                    records.Clear();
//                }
//            }

//            if (records.Count > 0)
//            {
//                await dbSet.AddRangeAsync(records);
//                await context.SaveChangesAsync();
//            }

//            Console.WriteLine($"{typeof(T).Name} data seeded successfully!");
//        }

//    }
//}












//using System;
//using System.Threading.Tasks;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Hosting;
//using AdminPortal.Data;
//using System.IO;
//using CsvHelper;
//using System.Globalization;
//using System.Linq;

//namespace AdminPortal
//{
//    class Program
//    {
//        static async Task Main(string[] args)
//        {
//            var host = CreateHostBuilder(args).Build();

//            using (var scope = host.Services.CreateScope())
//            {
//                var services = scope.ServiceProvider;
//                try
//                {
//                    var context = services.GetRequiredService<AdminPortalDbContext>();
//                    // Apply pending migrations
//                    await context.Database.MigrateAsync();

//                    // Seed data from CSV files
//                    await AdminPortalDbContext.SeedDataAsync(context); 
//                }
//                catch (Exception ex)
//                {
//                    Console.WriteLine($"An error occurred while migrating or seeding the database: {ex.Message}");
//                }
//            }

//            await host.RunAsync();
//        }

//        public static IHostBuilder CreateHostBuilder(string[] args) =>
//            Host.CreateDefaultBuilder(args)
//                .ConfigureServices((hostContext, services) =>
//                {
//                    services.AddDbContext<AdminPortalDbContext>(options =>
//                        options.UseSqlServer("Server=DESKTOP-U58E1DM\\SQLEXPRESS;Database=AdminPortal;Trusted_Connection=True;Encrypt=False;"));
//                });
//    }
//}
