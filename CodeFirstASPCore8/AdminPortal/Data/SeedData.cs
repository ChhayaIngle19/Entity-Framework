//using System;
//using System.Globalization;
//using CsvHelper;
//using CsvHelper.Configuration;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.DependencyInjection;
//using AdminPortal.Models;

//namespace AdminPortal.Data
//{
//    public static class SeedData
//    {
//        public static async Task InitializeAsync(IServiceProvider serviceProvider)
//        {
//            // Create a database context instance
//            using (var context = new AdminPortalDbContext(
//                serviceProvider.GetRequiredService<DbContextOptions<AdminPortalDbContext>>()))
//            {
//                // Ensure database is created
//                await context.Database.MigrateAsync();

//                // Check if data exists to prevent duplicate seeding

//                if (!await context.Country.AnyAsync())
//                    await SeedCountriesAsync(context, @"C:\Users\hp\Downloads\Admin Portal\csv file\Country.csv");

//                if (!await context.StateProvince.AnyAsync())
//                    await SeedStateProvincesAsync(context, @"C:\Users\hp\Downloads\Admin Portal\csv file\StateProvince.csv");

//                if (!await context.Employee.AnyAsync())
//                    await SeedEmployeesAsync(context, @"C:\Users\hp\Downloads\Admin Portal\csv file\Employee.csv");

//                if (!await context.HCP.AnyAsync())
//                    await SeedHCPsAsync(context, @"C:\Users\hp\Downloads\Admin Portal\csv file\HCP.csv");

//                if(!await context.Region.AnyAsync())
//                    await SeedRegionsAsync(context, @"C:\Users\hp\Downloads\Admin Portal\csv file\Region.csv");

              
//                if (!await context.Hospital.AnyAsync())
//                    await SeedHospitalsAsync(context, @"C:\Users\hp\Downloads\Admin Portal\csv file\Hospital.csv");

         
//                if (!await context.PersonName.AnyAsync())
//                    await SeedPersonNamesAsync(context, @"C:\Users\hp\Downloads\Admin Portal\csv file\PersonName.csv");

//                if (!await context.Address.AnyAsync())
//                    await SeedAddressesAsync(context, @"C:\Users\hp\Downloads\Admin Portal\csv file\Address.csv");
//            }
//        }

//        private static async Task SeedHCPsAsync(AdminPortalDbContext context, string filePath)
//        {
//            if (File.Exists(filePath))  //check if file exists
//            {
//                using (var reader = new StreamReader(filePath)) //read the file
//                using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture))) //read the file using csvhelper
//                {
//                    var records = csv.GetRecords<HCP>().ToList();   // Convert CSV data to a list of `HCP` objects
//                    await context.HCP.AddRangeAsync(records);   //insert data into database
//                    await context.SaveChangesAsync();   //save changes
//                }
//            }
//        }

//        private static async Task SeedRegionsAsync(AdminPortalDbContext context, string filePath)
//        {
//            if (File.Exists(filePath))
//            {
//                using (var reader = new StreamReader(filePath))
//                using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
//                {
//                    var records = csv.GetRecords<Region>().ToList();
//                    await context.Region.AddRangeAsync(records);
//                    await context.SaveChangesAsync();
//                }
//            }
//        }

//        private static async Task SeedStateProvincesAsync(AdminPortalDbContext context, string filePath)
//        {
//            if (File.Exists(filePath))
//            {
//                using (var reader = new StreamReader(filePath))
//                using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
//                {
//                    var records = csv.GetRecords<StateProvince>().ToList();
//                    await context.StateProvince.AddRangeAsync(records);
//                    await context.SaveChangesAsync();
//                }
//            }
//        }

//        private static async Task SeedHospitalsAsync(AdminPortalDbContext context, string filePath)
//        {
//            if (File.Exists(filePath))
//            {
//                using (var reader = new StreamReader(filePath))
//                using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
//                {
//                    var records = csv.GetRecords<Hospital>().ToList();
//                    await context.Hospital.AddRangeAsync(records);
//                    await context.SaveChangesAsync();
//                }
//            }
//        }

//        private static async Task SeedCountriesAsync(AdminPortalDbContext context, string filePath)
//        {
//            if (File.Exists(filePath))
//            {
//                using (var reader = new StreamReader(filePath))
//                using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
//                {
//                    var records = csv.GetRecords<Country>().ToList();
//                    await context.Country.AddRangeAsync(records);
//                    await context.SaveChangesAsync();
//                }
//            }
//        }

//        private static async Task SeedPersonNamesAsync(AdminPortalDbContext context, string filePath)
//        {
//            if (File.Exists(filePath))
//            {
//                using (var reader = new StreamReader(filePath))
//                using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
//                {
//                    var records = csv.GetRecords<PersonName>().ToList();
//                    await context.PersonName.AddRangeAsync(records);
//                    await context.SaveChangesAsync();
//                }
//            }
//        }

//        private static async Task SeedEmployeesAsync(AdminPortalDbContext context, string filePath)
//        {
//            if (File.Exists(filePath))
//            {
//                using (var reader = new StreamReader(filePath))
//                using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
//                {
//                    var records = csv.GetRecords<Employee>().ToList();
//                    await context.Employee.AddRangeAsync(records);
//                    await context.SaveChangesAsync();
//                }
//            }
//        }
//        private static async Task SeedAddressesAsync(AdminPortalDbContext context, string filePath)
//        {
//            if (File.Exists(filePath))
//            {
//                using (var reader = new StreamReader(filePath))
//                using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
//                {
//                    var records = csv.GetRecords<Address>().ToList();
//                    await context.Address.AddRangeAsync(records);
//                    await context.SaveChangesAsync();
//                }
//            }
//        }    
//    }
//}
