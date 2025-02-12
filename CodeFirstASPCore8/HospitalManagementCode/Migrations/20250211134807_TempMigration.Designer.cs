﻿// <auto-generated />
using System;
using HospitalManagementCode.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HospitalManagementCode.Migrations
{
    [DbContext(typeof(AdminPortalDBContext))]
    [Migration("20250211134807_TempMigration")]
    partial class TempMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HospitalManagementCode.Models.Address", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.Property<DateTime>("CreatedTimestamp")
                        .HasColumnType("datetime2");

                    b.Property<long?>("EmployeeId")
                        .HasColumnType("bigint");

                    b.Property<string>("Line1")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Line2")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("StateProvince")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("UpdatedTimestamp")
                        .HasColumnType("datetime2");

                    b.Property<string>("ZipPinCode")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("HospitalManagementCode.Models.Country", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Abbr")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Continent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CountryCode")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<DateTime>("CreatedTimestamp")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.Property<DateTime>("UpdatedTimestamp")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Country");
                });

            modelBuilder.Entity("HospitalManagementCode.Models.Employee", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedTimestamp")
                        .HasColumnType("datetime2");

                    b.Property<DateOnly>("DateOfBirth")
                        .HasColumnType("date");

                    b.Property<string>("Email_Personal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email_Work")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("EmployeeNameId")
                        .HasColumnType("bigint");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("HCP")
                        .HasColumnType("bigint");

                    b.Property<int>("HCPId")
                        .HasColumnType("int");

                    b.Property<long?>("HCPId1")
                        .HasColumnType("bigint");

                    b.Property<long?>("HCPId2")
                        .HasColumnType("bigint");

                    b.Property<DateOnly>("HireDate")
                        .HasColumnType("date");

                    b.Property<long?>("HomeAddressId")
                        .HasColumnType("bigint");

                    b.Property<long?>("HospitalId")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsClinician")
                        .HasColumnType("bit");

                    b.Property<string>("Mobile_Personal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mobile_Work")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("RegionId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("UpdatedTimestamp")
                        .HasColumnType("datetime2");

                    b.Property<long?>("WorkAddressId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeNameId");

                    b.HasIndex("HCPId1");

                    b.HasIndex("HCPId2");

                    b.HasIndex("HomeAddressId");

                    b.HasIndex("HospitalId");

                    b.HasIndex("RegionId");

                    b.HasIndex("WorkAddressId");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("HospitalManagementCode.Models.HCP", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedTimestamp")
                        .HasColumnType("datetime2");

                    b.Property<long?>("HCPAddressId")
                        .HasColumnType("bigint");

                    b.Property<long?>("HCPRegionIdId")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsLicenseKeyActivated")
                        .HasColumnType("bit");

                    b.Property<bool>("IsSecretKeyEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastUpdatedTimestamp")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<long?>("PrimaryAdminId")
                        .HasColumnType("bigint");

                    b.Property<long?>("PrimaryInformationAnalystId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("HCPAddressId");

                    b.HasIndex("HCPRegionIdId");

                    b.HasIndex("PrimaryAdminId");

                    b.HasIndex("PrimaryInformationAnalystId");

                    b.ToTable("HCP");
                });

            modelBuilder.Entity("HospitalManagementCode.Models.Hospital", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<short>("Beds")
                        .HasColumnType("smallint");

                    b.Property<DateTime>("CreateTimestamp")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<long?>("HospitalAddressId")
                        .HasColumnType("bigint");

                    b.Property<short>("InPatientGroupsCount")
                        .HasColumnType("smallint");

                    b.Property<string>("Logo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<long?>("PrimaryAdminId")
                        .HasColumnType("bigint");

                    b.Property<string>("ProfileImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("RegionId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("UpdateTimestamp")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("HospitalAddressId");

                    b.HasIndex("PrimaryAdminId");

                    b.HasIndex("RegionId")
                        .IsUnique()
                        .HasFilter("[RegionId] IS NOT NULL");

                    b.ToTable("Hospital");
                });

            modelBuilder.Entity("HospitalManagementCode.Models.PersonName", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreateTimeStamp")
                        .HasColumnType("datetime2");

                    b.Property<long?>("EmployeeId")
                        .HasColumnType("bigint");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("LastUpdateTimeStamp")
                        .HasColumnType("datetime2");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("NamePrefixType")
                        .HasColumnType("int");

                    b.Property<int?>("NameSuffixType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("PersonName");
                });

            modelBuilder.Entity("HospitalManagementCode.Models.Region", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedTimestamp")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastUpdatedTimestamp")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<long?>("PrimaryAdminId")
                        .HasColumnType("bigint");

                    b.Property<long?>("StateProvinceId")
                        .HasColumnType("bigint");

                    b.Property<int?>("StateProvincesId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PrimaryAdminId");

                    b.HasIndex("StateProvincesId");

                    b.ToTable("Region");
                });

            modelBuilder.Entity("HospitalManagementCode.Models.StateProvince", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Abbr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("CountryId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedTimestamp")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<long?>("StateHospitalsId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("UpdatedTimestamp")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.HasIndex("StateHospitalsId");

                    b.ToTable("StateProvince");
                });

            modelBuilder.Entity("HospitalManagementCode.Models.Address", b =>
                {
                    b.HasOne("HospitalManagementCode.Models.Employee", null)
                        .WithMany("Addresses")
                        .HasForeignKey("EmployeeId");
                });

            modelBuilder.Entity("HospitalManagementCode.Models.Employee", b =>
                {
                    b.HasOne("HospitalManagementCode.Models.PersonName", "EmployeeName")
                        .WithMany("Employees")
                        .HasForeignKey("EmployeeNameId");

                    b.HasOne("HospitalManagementCode.Models.HCP", null)
                        .WithMany("SecondaryAdmin")
                        .HasForeignKey("HCPId1");

                    b.HasOne("HospitalManagementCode.Models.HCP", null)
                        .WithMany("SecondaryInformationAnalyst")
                        .HasForeignKey("HCPId2");

                    b.HasOne("HospitalManagementCode.Models.Address", "HomeAddress")
                        .WithMany()
                        .HasForeignKey("HomeAddressId");

                    b.HasOne("HospitalManagementCode.Models.Hospital", null)
                        .WithMany("SecondaryAdmins")
                        .HasForeignKey("HospitalId");

                    b.HasOne("HospitalManagementCode.Models.Region", null)
                        .WithMany("SecondaryAdmin")
                        .HasForeignKey("RegionId");

                    b.HasOne("HospitalManagementCode.Models.Address", "WorkAddress")
                        .WithMany()
                        .HasForeignKey("WorkAddressId");

                    b.Navigation("EmployeeName");

                    b.Navigation("HomeAddress");

                    b.Navigation("WorkAddress");
                });

            modelBuilder.Entity("HospitalManagementCode.Models.HCP", b =>
                {
                    b.HasOne("HospitalManagementCode.Models.Address", "HCPAddress")
                        .WithMany("HCPs")
                        .HasForeignKey("HCPAddressId");

                    b.HasOne("HospitalManagementCode.Models.Region", "HCPRegionId")
                        .WithMany("HCPs")
                        .HasForeignKey("HCPRegionIdId");

                    b.HasOne("HospitalManagementCode.Models.Employee", "PrimaryAdmin")
                        .WithMany()
                        .HasForeignKey("PrimaryAdminId");

                    b.HasOne("HospitalManagementCode.Models.Employee", "PrimaryInformationAnalyst")
                        .WithMany()
                        .HasForeignKey("PrimaryInformationAnalystId");

                    b.Navigation("HCPAddress");

                    b.Navigation("HCPRegionId");

                    b.Navigation("PrimaryAdmin");

                    b.Navigation("PrimaryInformationAnalyst");
                });

            modelBuilder.Entity("HospitalManagementCode.Models.Hospital", b =>
                {
                    b.HasOne("HospitalManagementCode.Models.Address", "HospitalAddress")
                        .WithMany("Hospitals")
                        .HasForeignKey("HospitalAddressId");

                    b.HasOne("HospitalManagementCode.Models.Employee", "PrimaryAdmin")
                        .WithMany()
                        .HasForeignKey("PrimaryAdminId");

                    b.HasOne("HospitalManagementCode.Models.Region", null)
                        .WithOne("RegionHospitals")
                        .HasForeignKey("HospitalManagementCode.Models.Hospital", "RegionId");

                    b.Navigation("HospitalAddress");

                    b.Navigation("PrimaryAdmin");
                });

            modelBuilder.Entity("HospitalManagementCode.Models.Region", b =>
                {
                    b.HasOne("HospitalManagementCode.Models.Employee", "PrimaryAdmin")
                        .WithMany()
                        .HasForeignKey("PrimaryAdminId");

                    b.HasOne("HospitalManagementCode.Models.StateProvince", "StateProvinces")
                        .WithMany()
                        .HasForeignKey("StateProvincesId");

                    b.Navigation("PrimaryAdmin");

                    b.Navigation("StateProvinces");
                });

            modelBuilder.Entity("HospitalManagementCode.Models.StateProvince", b =>
                {
                    b.HasOne("HospitalManagementCode.Models.Country", null)
                        .WithMany("CountryStateProvinces")
                        .HasForeignKey("CountryId");

                    b.HasOne("HospitalManagementCode.Models.Hospital", "StateHospitals")
                        .WithMany()
                        .HasForeignKey("StateHospitalsId");

                    b.Navigation("StateHospitals");
                });

            modelBuilder.Entity("HospitalManagementCode.Models.Address", b =>
                {
                    b.Navigation("HCPs");

                    b.Navigation("Hospitals");
                });

            modelBuilder.Entity("HospitalManagementCode.Models.Country", b =>
                {
                    b.Navigation("CountryStateProvinces");
                });

            modelBuilder.Entity("HospitalManagementCode.Models.Employee", b =>
                {
                    b.Navigation("Addresses");
                });

            modelBuilder.Entity("HospitalManagementCode.Models.HCP", b =>
                {
                    b.Navigation("SecondaryAdmin");

                    b.Navigation("SecondaryInformationAnalyst");
                });

            modelBuilder.Entity("HospitalManagementCode.Models.Hospital", b =>
                {
                    b.Navigation("SecondaryAdmins");
                });

            modelBuilder.Entity("HospitalManagementCode.Models.PersonName", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("HospitalManagementCode.Models.Region", b =>
                {
                    b.Navigation("HCPs");

                    b.Navigation("RegionHospitals");

                    b.Navigation("SecondaryAdmin");
                });
#pragma warning restore 612, 618
        }
    }
}
