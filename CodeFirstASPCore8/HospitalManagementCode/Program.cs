using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using HospitalManagementCode.Data;

class Program
{
    static async Task Main()
    {
        // Step 1: Create a new service collection
        var services = new ServiceCollection();
        ConfigureServices(services);  // Configure required services

        // Step 2: Build the service provider
        using var serviceProvider = services.BuildServiceProvider();
        using var scope = serviceProvider.CreateScope();

        // Step 3: Resolve the database context
        var context = scope.ServiceProvider.GetRequiredService<AdminPortalDBContext>();

        try
        {
            Console.WriteLine("Applying Migrations...");
            await context.Database.MigrateAsync();  // Ensure the latest migrations are applied

            Console.WriteLine("Seeding Data...");
            await AdminPortalDBContext.SeedDataAsync(context);  // Seed data after migration
            Console.WriteLine("Seeding Completed!");

            Console.WriteLine("Fetching Seeded Data:");
            await DisplaySeededDataAsync(context);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }

        Console.WriteLine("Database setup complete. Press any key to exit...");
        Console.ReadKey();
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<AdminPortalDBContext>(options =>
            options.UseSqlServer("Server=DESKTOP-U58E1DM\\SQLEXPRESS;Database=AdminPortalDB;Trusted_Connection=True;Encrypt=False;"));
    }

    private static async Task DisplaySeededDataAsync(AdminPortalDBContext context)
    {
        //fetch and display countries
        var countries = await context.Country.ToListAsync();
        Console.WriteLine("Countries:");
        foreach (var country in countries)
        {
            Console.WriteLine($"- {country.Name} ({country.Abbr})");
        }


        // Fetch and display states
        var states = await context.StateProvince.ToListAsync();
        Console.WriteLine("States:");
        foreach (var state in states)
        {
            Console.WriteLine($"- {state.Name} ({state.Abbr}) - CountryId: {state.CountryId}");
        }

        // Fetch and display employees
        var employees = await context.Employee.ToListAsync();
        Console.WriteLine("Employees:");
        foreach (var employee in employees)
        {
            Console.WriteLine($"- Email: {employee.Email_Work}, Gender: {employee.Gender}, HireDate: {employee.HireDate}, Active: {employee.IsActive}");
        }

        // Fetch and display hospitals
        var hospitals = await context.Hospital.ToListAsync();
        Console.WriteLine("Hospitals:");
        foreach (var hospital in hospitals)
        {
            Console.WriteLine($"- {hospital.Name} ({hospital.Description})");
        }

        // Fetch and display HCPs
        var hcps = await context.HCP.ToListAsync();
        Console.WriteLine("Healthcare Providers:");
        foreach (var hcp in hcps)
        {
            Console.WriteLine($"- {hcp.Name}, Secret Key Enabled: {hcp.IsSecretKeyEnabled}, License Key Activated: {hcp.IsLicenseKeyActivated}");
        }

        // Fetch and display regions
        var regions = await context.Region.ToListAsync();
        Console.WriteLine("Regions:");
        foreach (var region in regions)
        {
            Console.WriteLine($"- {region.Name}");
        }

        // Fetch and display addresses
        var addresses = await context.Address.ToListAsync();
        Console.WriteLine("Addresses:");
        foreach (var address in addresses)
        {
            Console.WriteLine($"- {address.Line1}, {address.City}, {address.StateProvince} {address.ZipPinCode}, {address.Country}");
        }

        // Fetch and display person names
        var personNames = await context.PersonName.ToListAsync();
        Console.WriteLine("Person Names:");
        foreach (var person in personNames)
        {
            Console.WriteLine($"- {person.FirstName} {person.MiddleName} {person.LastName}");
        }
    }
}
