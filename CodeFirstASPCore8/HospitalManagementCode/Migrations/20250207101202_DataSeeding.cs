using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HospitalManagementCode.Migrations
{
    /// <inheritdoc />
    public partial class DataSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "Id", "City", "Country", "CreatedTimestamp", "EmployeeId", "Line1", "Line2", "StateProvince", "UpdatedTimestamp", "WorkEmployeeId", "ZipPinCode" },
                values: new object[,]
                {
                    { 1L, "Los Angeles", "USA", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "123 Main St", "Suite 100", "CA", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "90001" },
                    { 2L, "Toronto", "Canada", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "456 Oak St", "Suite 200", "ON", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "M5H 2N2" },
                    { 3L, "San Francisco", "USA", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "789 Maple Rd", "Apt 303", "CA", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "94110" },
                    { 4L, "Vancouver", "Canada", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "101 Pine St", "Suite 5", "BC", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "V6B 1A4" },
                    { 5L, "New York", "USA", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "202 Birch Ave", "Unit 7", "NY", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "10001" }
                });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Id", "Abbr", "Continent", "CountryCode", "CreatedTimestamp", "Name", "UpdatedTimestamp" },
                values: new object[,]
                {
                    { 1L, "USA", "North America", "US", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "United States", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2L, "CAN", "North America", "CA", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Canada", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3L, "UK", "Europe", "UK", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "United Kingdom", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4L, "DE", "Europe", "DE", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Germany", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5L, "AUS", "Oceania", "AU", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Australia", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "Id", "CreatedTimestamp", "DateOfBirth", "Email_Personal", "Email_Work", "EmployeeNameId", "Gender", "HCPId", "HCPId1", "HireDate", "HomeAddressId", "HospitalId", "IsActive", "IsClinician", "Mobile_Personal", "Mobile_Work", "RegionId", "UpdatedTimestamp", "WorkAddressId" },
                values: new object[,]
                {
                    { 1L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(1990, 5, 20), null, "admin@hospital.com", null, "Male", null, null, new DateOnly(2015, 1, 1), null, null, true, true, null, "1234567890", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(1985, 8, 10), null, "doctor@hospital.com", null, "Female", null, null, new DateOnly(2017, 3, 15), null, null, true, true, null, "9876543210", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 3L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(1980, 11, 25), null, "nurse@hospital.com", null, "Male", null, null, new DateOnly(2019, 6, 12), null, null, true, false, null, "5551234567", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 4L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(1992, 3, 7), null, "pharmacist@hospital.com", null, "Female", null, null, new DateOnly(2020, 1, 20), null, null, true, false, null, "5559876543", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 5L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(1995, 6, 15), null, "admin2@hospital.com", null, "Male", null, null, new DateOnly(2022, 9, 10), null, null, true, true, null, "5555555555", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null }
                });

            migrationBuilder.InsertData(
                table: "HCP",
                columns: new[] { "Id", "CreatedTimestamp", "HCPAddressId", "HCPRegionIdId", "IsLicenseKeyActivated", "IsSecretKeyEnabled", "LastUpdatedTimestamp", "Name", "PrimaryAdminId", "PrimaryInformationAnalystId" },
                values: new object[,]
                {
                    { 1L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, true, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Healthcare Provider 1", null, null },
                    { 2L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, true, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Healthcare Provider 2", null, null },
                    { 3L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Healthcare Provider 3", null, null },
                    { 4L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Healthcare Provider 4", null, null },
                    { 5L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, true, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Healthcare Provider 5", null, null }
                });

            migrationBuilder.InsertData(
                table: "Hospital",
                columns: new[] { "Id", "Beds", "CreateTimestamp", "Description", "HospitalAddressId", "InPatientGroupsCount", "Logo", "Name", "PrimaryAdminId", "ProfileImage", "RegionId", "UpdateTimestamp" },
                values: new object[,]
                {
                    { 1L, (short)0, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A major hospital in the city", null, (short)0, null, "General Hospital", null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2L, (short)0, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A community hospital", null, (short)0, null, "City Health Center", null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3L, (short)0, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Specialty care hospital", null, (short)0, null, "Northside Medical", null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4L, (short)0, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Primary care and urgent care services", null, (short)0, null, "Sunrise Clinic", null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5L, (short)0, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A hospital located on the coast", null, (short)0, null, "Coastal Hospital", null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "PersonName",
                columns: new[] { "Id", "CreateTimeStamp", "EmployeeId", "FirstName", "LastName", "LastUpdateTimeStamp", "MiddleName", "NamePrefixType", "NameSuffixType" },
                values: new object[,]
                {
                    { 1L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "John", "Doe", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A.", null, null },
                    { 2L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Jane", "Smith", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "B.", null, null },
                    { 3L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Michael", "Johnson", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "C.", null, null },
                    { 4L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Emily", "Davis", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "D.", null, null },
                    { 5L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "David", "Wilson", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "E.", null, null }
                });

            migrationBuilder.InsertData(
                table: "Region",
                columns: new[] { "Id", "CreatedTimestamp", "LastUpdatedTimestamp", "Name", "PrimaryAdminId", "StateProvinceId", "StateProvincesId" },
                values: new object[,]
                {
                    { 1L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "West Coast", null, null, null },
                    { 2L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Eastern Canada", null, null, null },
                    { 3L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Midwest USA", null, null, null },
                    { 4L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Southeast Asia", null, null, null },
                    { 5L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Central Europe", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "StateProvince",
                columns: new[] { "Id", "Abbr", "CountryId", "CreatedTimestamp", "Name", "StateHospitalsId", "UpdatedTimestamp" },
                values: new object[,]
                {
                    { 1, "CA", 1L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "California", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "ON", 2L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ontario", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "BY", 4L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bavaria", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "NSW", 5L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "New South Wales", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "LDN", 3L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "London", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Address",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Address",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Address",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Address",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Address",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "HCP",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "HCP",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "HCP",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "HCP",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "HCP",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Hospital",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Hospital",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Hospital",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Hospital",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Hospital",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "PersonName",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "PersonName",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "PersonName",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "PersonName",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "PersonName",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Region",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Region",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Region",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Region",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Region",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 5L);
        }
    }
}
