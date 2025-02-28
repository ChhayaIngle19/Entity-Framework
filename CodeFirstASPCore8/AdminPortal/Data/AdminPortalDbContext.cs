using System;
using System.Collections.Generic;
using System.Globalization;
using CsvHelper;
using System.IO;
using System.Linq;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;
using Microsoft.EntityFrameworkCore;
using AdminPortal.Models;

namespace AdminPortal.Data
{
    public class AdminPortalDbContext : DbContext
    {
        public AdminPortalDbContext() { }

        public AdminPortalDbContext(DbContextOptions<AdminPortalDbContext> options) : base(options) { }

        //public DbSet<HCP> HCP { get; set; }
        //public DbSet<Region> Region { get; set; }
        //public DbSet<StateProvince> StateProvince { get; set; }
        public DbSet<Country> Country { get; set; }
        //public DbSet<Hospital> Hospital { get; set; }
        //public DbSet<Employee> Employee { get; set; }
        //public DbSet<PersonName> PersonName { get; set; }
        //public DbSet<Address> Address { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-U58E1DM\\SQLEXPRESS;Database=AdminPortal;Trusted_Connection=True;Encrypt=False;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>()
                .HasIndex(c => c.Abbr)
                .IsUnique(); // Ensures Abbr is unique at the DB level
        }

        public static async Task SeedDataAsync(AdminPortalDbContext context)
        {
            try
            {
                Console.WriteLine("Checking if data seeding is required...");

                // Seeding Countries from CSV
                
                if (!await context.Country.AnyAsync())
                {
                    var filePath = "C:\\Users\\hp\\source\\repos\\Entity-Framework\\CodeFirstASPCore8\\AdminPortal\\AdminPortal_csv\\Country.csv";
                    //var filePath = "C:\\Users\\hp\\Desktop\\country1.txt";

                    var batchSize = 1000; // Adjust the batch size as needed

                    using (var reader = new StreamReader(filePath))
                    using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        MissingFieldFound = null
                    }))
                    {
                        var records = new List<Country>();
                        while (csv.Read())
                        {
                            var record = csv.GetRecord<Country>();  // Reads a row and maps it to Country class
                            records.Add(record);

                            if (records.Count >= batchSize)
                            {
                                await context.Country.AddRangeAsync(records);
                                await context.SaveChangesAsync();
                                records.Clear();
                            }
                        }
                        // Insert any remaining records
                        if (records.Count > 0)
                        {
                            await context.Country.AddRangeAsync(records);
                            await context.SaveChangesAsync();
                        }
                    }

                    Console.WriteLine("Country data seeded successfully!");
                }


                //if (!await context.Country.AnyAsync())
                //{
                //    var countries = ReadCsv<Country>("C:\\Users\\hp\\source\\repos\\Entity-Framework\\CodeFirstASPCore8\\AdminPortal\\AdminPortal_csv\\Country.csv");

                //    await context.Country.AddRangeAsync(countries);

                //    await context.SaveChangesAsync();
                //    Console.WriteLine("Country data seeded successfully!");
                //}

                //// Seeding StateProvinces from CSV
                //if (!await context.StateProvince.AnyAsync())
                //{
                //    var states = ReadCsv<StateProvince>("C:\\Users\\hp\\source\\repos\\Entity-Framework\\CodeFirstASPCore8\\AdminPortal\\AdminPortal_csv\\StateProvince.csv");
                //    await context.StateProvince.AddRangeAsync(states);
                //    await context.SaveChangesAsync();
                //    Console.WriteLine("StateProvince data seeded successfully!");
                //}

                //// Seeding Employees from CSV
                //if (!await context.Employee.AnyAsync())
                //{
                //    var employees = ReadCsv<Employee>("Data/Employee.csv");
                //    await context.Employee.AddRangeAsync(employees);
                //    await context.SaveChangesAsync();
                //}

                ////seeding HCPs from CSV
                //if (!await context.HCP.AnyAsync())
                //{
                //    var hcps = ReadCsv<HCP>("Data/HCP.csv");
                //    await context.HCP.AddRangeAsync(hcps);
                //    await context.SaveChangesAsync();
                //}

                //// Seeding Regions from CSV
                //if (!await context.Region.AnyAsync())
                //{
                //    var regions = ReadCsv<Region>("Data/Region.csv");
                //    await context.Region.AddRangeAsync(regions);
                //    await context.SaveChangesAsync();
                //}

                //// Seeding Hospitals from CSV
                //if (!await context.Hospital.AnyAsync())
                //{
                //    var hospitals = ReadCsv<Hospital>("Data/Hospital.csv");
                //    await context.Hospital.AddRangeAsync(hospitals);
                //    await context.SaveChangesAsync();
                //}

                ////seeding addresses from CSV
                //if (!await context.Address.AnyAsync())
                //{
                //    var addresses = ReadCsv<Address>("Data/Address.csv");
                //    await context.Address.AddRangeAsync(addresses);
                //    await context.SaveChangesAsync();
                //}

                //// Seeding PersonNames from CSV
                //if (!await context.PersonName.AnyAsync())
                //{
                //    var personNames = ReadCsv<PersonName>("Data/PersonName.csv");
                //    await context.PersonName.AddRangeAsync(personNames);
                //    await context.SaveChangesAsync();
                //}


                Console.WriteLine("Seeding completed successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while seeding data: {ex.Message}");
            }
        }

        private static List<T> ReadCsv<T>(string filePath)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"File not found: {filePath}");
                return new List<T>();
            }

            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
            {
                return csv.GetRecords<T>().ToList();
            }
        }
    }
}





//using System;
//using Microsoft.EntityFrameworkCore;
//using AdminPortal.Models;

//namespace AdminPortal.Data
//{
//    public class AdminPortalDbContext : DbContext
//    {
//        // Default constructor for design-time support
//        public AdminPortalDbContext() { }

//        public AdminPortalDbContext(DbContextOptions<AdminPortalDbContext> options) : base(options)
//        {
//        }

//        public DbSet<HCP> HCP { get; set; }
//        public DbSet<Region> Region { get; set; }
//        public DbSet<StateProvince> StateProvince { get; set; }
//        public DbSet<Country> Country { get; set; }
//        public DbSet<Hospital> Hospital { get; set; }
//        public DbSet<Employee> Employee { get; set; }
//        public DbSet<PersonName> PersonName { get; set; }
//        public DbSet<Address> Address { get; set; }

//        // Configuring SQL Server connection (Only if not configured in Program.cs)
//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//                optionsBuilder.UseSqlServer("Server=DESKTOP-U58E1DM\\SQLEXPRESS;Database=AdminPortal;Trusted_Connection=True;Encrypt=False;");
//            }
//        }

//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            base.OnModelCreating(modelBuilder);

//            //// Address -> Employee
//            //modelBuilder.Entity<Address>()
//            //    .HasOne(a => a.Employee)
//            //    .WithMany(e => e.Address)
//            //    .HasForeignKey(a => a.EmployeeId)
//            //    .OnDelete(DeleteBehavior.Restrict);

//            // Employee ↔ Address (One-to-Many)
//            modelBuilder.Entity<Address>()
//                .HasOne(a => a.Employee)
//                .WithMany(e => e.Addresses)
//                .HasForeignKey(a => a.EmployeeId)
//                .OnDelete(DeleteBehavior.Cascade);

//            // Employee ↔ HCP (Many-to-One)
//            modelBuilder.Entity<Employee>()
//                .HasOne(e => e.HCP)
//                .WithMany(h => h.Employee)
//                .HasForeignKey(e => e.HCPId)
//                .OnDelete(DeleteBehavior.Cascade);

//            // Region -> HCP
//            modelBuilder.Entity<Region>()
//                .HasOne(r => r.HCP)
//                .WithMany()
//                .HasForeignKey(r => r.HCPId)
//                .OnDelete(DeleteBehavior.Restrict);

//            // HCP -> PrimaryAdmin (Employee)
//            modelBuilder.Entity<HCP>()
//                .HasOne(h => h.PrimaryAdmin)
//                .WithMany()
//                .HasForeignKey(h => h.EmployeeId)
//                .OnDelete(DeleteBehavior.Restrict);

//        }

//    }
//}





