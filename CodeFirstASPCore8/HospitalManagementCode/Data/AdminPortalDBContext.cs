using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HospitalManagementCode.Models;

namespace HospitalManagementCode.Data
{
    public class AdminPortalDBContext : DbContext
    {
        // Default constructor for design-time support
        public AdminPortalDBContext() { }

        public AdminPortalDBContext(DbContextOptions<AdminPortalDBContext> options) : base(options) { }

        public DbSet<HCP> HCP { get; set; }
        public DbSet<Region> Region { get; set; }
        public DbSet<StateProvince> StateProvince { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<Hospital> Hospital { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<PersonName> PersonName { get; set; }
        public DbSet<Address> Address { get; set; }

        // Configuring SQL Server connection (Only if not configured in Program.cs)
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-U58E1DM\\SQLEXPRESS;Database=AdminPortalDB;Trusted_Connection=True;Encrypt=False;");
            }
        }

        // Async method for seeding data
        public static async Task SeedDataAsync(AdminPortalDBContext context)
        {
            try
            {
                Console.WriteLine("Checking if data seeding is required...");

                // Define the static timestamp for consistent timestamps
                DateTime staticTimestamp = new DateTime(2024, 1, 1);

                // Seeding Countries
                if (!await context.Country.AnyAsync())
                {
                    var countries = new List<Country>
                    {
                        new Country { Name = "United States", Abbr = "USA", CountryCode = "US", Continent = "North America", CreatedTimestamp=  },
                        new Country { Name = "Canada", Abbr = "CAN", CountryCode = "CA", Continent = "North America" }
                    };

                    await context.Country.AddRangeAsync(countries);
                    await context.SaveChangesAsync();
                }

                // Seeding States
                if (!await context.StateProvince.AnyAsync())
                {
                    var states = new List<StateProvince>
                    {
                        new StateProvince { Name = "California", Abbr = "CA", CountryId = 1 },
                        new StateProvince { Name = "Ontario", Abbr = "ON", CountryId = 2 }
                    };

                    await context.StateProvince.AddRangeAsync(states);
                    await context.SaveChangesAsync();
                }

                // Seeding Employees
                if (!await context.Employee.AnyAsync())
                {
                    var employees = new List<Employee>
                    {
                        new Employee { Email_Work = "admin@hospital.com", Gender = "Male", HireDate = new DateOnly(2015, 1, 1), IsActive = true },
                        new Employee { Email_Work = "doctor@hospital.com", Gender = "Female", HireDate = new DateOnly(2017, 3, 15), IsActive = true }
                    };

                    await context.Employee.AddRangeAsync(employees);
                    await context.SaveChangesAsync();
                }

                // Seeding Hospitals
                if (!await context.Hospital.AnyAsync())
                {
                    var hospitals = new List<Hospital>
                    {
                        new Hospital { Name = "General Hospital", Description = "A major hospital in the city" },
                        new Hospital { Name = "City Health Center", Description = "A community hospital" }
                    };

                    await context.Hospital.AddRangeAsync(hospitals);
                    await context.SaveChangesAsync();
                }

                // Seeding Healthcare Providers
                if (!await context.HCP.AnyAsync())
                {
                    var hcps = new List<HCP>
                    {
                        new HCP { Name = "Healthcare Provider 1", IsSecretKeyEnabled = true, IsLicenseKeyActivated = false },
                        new HCP { Name = "Healthcare Provider 2", IsSecretKeyEnabled = true, IsLicenseKeyActivated = true }
                    };

                    await context.HCP.AddRangeAsync(hcps);
                    await context.SaveChangesAsync();
                }

                // Seeding Regions
                if (!await context.Region.AnyAsync())
                {
                    var regions = new List<Region>
                    {
                        new Region { Name = "West Coast", CreatedTimestamp = staticTimestamp, LastUpdatedTimestamp = staticTimestamp },
                        new Region { Name = "Eastern Canada", CreatedTimestamp = staticTimestamp, LastUpdatedTimestamp = staticTimestamp }
                    };

                    await context.Region.AddRangeAsync(regions);
                    await context.SaveChangesAsync();
                }

                // Seeding Addresses
                if (!await context.Address.AnyAsync())
                {
                    Console.WriteLine("Seeding Addresses...");

                    var addresses = new List<Address>
                    {
                        new Address { Line1 = "123 Main St", Line2 = "Suite 100", City = "Los Angeles", StateProvince = "CA", ZipPinCode = "90001", Country = "USA", CreatedTimestamp = staticTimestamp, UpdatedTimestamp = staticTimestamp },
                        new Address { Line1 = "456 Oak St", Line2 = "Suite 200", City = "Toronto", StateProvince = "ON", ZipPinCode = "M5H 2N2", Country = "Canada", CreatedTimestamp = staticTimestamp, UpdatedTimestamp = staticTimestamp }
                    };

                    await context.Address.AddRangeAsync(addresses);
                    await context.SaveChangesAsync();

                    Console.WriteLine("Addresses seeded successfully!");
                }

                // Seeding PersonNames
                if (!await context.PersonName.AnyAsync())
                {
                    Console.WriteLine("Seeding PersonNames...");

                    var personNames = new List<PersonName>
                    {
                        new PersonName { FirstName = "John", MiddleName = "A.", LastName = "Doe", CreateTimeStamp = staticTimestamp, LastUpdateTimeStamp = staticTimestamp },
                        new PersonName { FirstName = "Jane", MiddleName = "B.", LastName = "Smith", CreateTimeStamp = staticTimestamp, LastUpdateTimeStamp = staticTimestamp }
                    };

                    await context.PersonName.AddRangeAsync(personNames);
                    await context.SaveChangesAsync();

                    Console.WriteLine("PersonNames seeded successfully!");
                }

                Console.WriteLine("Seeding completed successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while seeding data: {ex.Message}");
            }
        }
    }
}
