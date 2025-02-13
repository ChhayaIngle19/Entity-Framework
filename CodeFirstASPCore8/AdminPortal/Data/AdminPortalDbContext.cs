using System;
using Microsoft.EntityFrameworkCore;
using AdminPortal.Models;

namespace AdminPortal.Data
{
    public class AdminPortalDbContext : DbContext
    {
        // Default constructor for design-time support
        public AdminPortalDbContext() { }

        public AdminPortalDbContext(DbContextOptions<AdminPortalDbContext> options) : base(options)
        {
        }

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
                optionsBuilder.UseSqlServer("Server=DESKTOP-U58E1DM\\SQLEXPRESS;Database=AdminPortal;Trusted_Connection=True;Encrypt=False;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Address -> Employee
            modelBuilder.Entity<Address>()
                .HasOne(a => a.Employee)
                .WithMany(e => e.Address)
                .HasForeignKey(a => a.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            // Region -> HCP
            modelBuilder.Entity<Region>()
                .HasOne(r => r.HCP)
                .WithMany()
                .HasForeignKey(r => r.HCPId)
                .OnDelete(DeleteBehavior.Restrict);

            // HCP -> PrimaryAdmin (Employee)
            modelBuilder.Entity<HCP>()
                .HasOne(h => h.PrimaryAdmin)
                .WithMany()
                .HasForeignKey(h => h.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);


        }
    }
}





