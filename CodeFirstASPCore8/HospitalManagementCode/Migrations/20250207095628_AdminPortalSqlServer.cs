using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalManagementCode.Migrations
{
    /// <inheritdoc />
    public partial class AdminPortalSqlServer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Abbr = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CountryCode = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Continent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedTimestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedTimestamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonName",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NamePrefixType = table.Column<int>(type: "int", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NameSuffixType = table.Column<int>(type: "int", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreateTimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateTimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmployeeId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonName", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Line1 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Line2 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StateProvince = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ZipPinCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    CreatedTimestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedTimestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WorkEmployeeId = table.Column<long>(type: "bigint", nullable: true),
                    EmployeeId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedTimestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedTimestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email_Work = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email_Personal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobile_Work = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobile_Personal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsClinician = table.Column<bool>(type: "bit", nullable: false),
                    HireDate = table.Column<DateOnly>(type: "date", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    EmployeeNameId = table.Column<long>(type: "bigint", nullable: true),
                    HomeAddressId = table.Column<long>(type: "bigint", nullable: true),
                    WorkAddressId = table.Column<long>(type: "bigint", nullable: true),
                    HCPId = table.Column<long>(type: "bigint", nullable: true),
                    HCPId1 = table.Column<long>(type: "bigint", nullable: true),
                    HospitalId = table.Column<long>(type: "bigint", nullable: true),
                    RegionId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employee_Address_HomeAddressId",
                        column: x => x.HomeAddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employee_Address_WorkAddressId",
                        column: x => x.WorkAddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Employee_PersonName_EmployeeNameId",
                        column: x => x.EmployeeNameId,
                        principalTable: "PersonName",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HCP",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsSecretKeyEnabled = table.Column<bool>(type: "bit", nullable: false),
                    IsLicenseKeyActivated = table.Column<bool>(type: "bit", nullable: false),
                    CreatedTimestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedTimestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HCPRegionIdId = table.Column<long>(type: "bigint", nullable: true),
                    PrimaryAdminId = table.Column<long>(type: "bigint", nullable: true),
                    PrimaryInformationAnalystId = table.Column<long>(type: "bigint", nullable: true),
                    HCPAddressId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HCP", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HCP_Address_HCPAddressId",
                        column: x => x.HCPAddressId,
                        principalTable: "Address",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HCP_Employee_PrimaryAdminId",
                        column: x => x.PrimaryAdminId,
                        principalTable: "Employee",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HCP_Employee_PrimaryInformationAnalystId",
                        column: x => x.PrimaryInformationAnalystId,
                        principalTable: "Employee",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Hospital",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ProfileImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Beds = table.Column<short>(type: "smallint", nullable: false),
                    InPatientGroupsCount = table.Column<short>(type: "smallint", nullable: false),
                    CreateTimestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTimestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RegionId = table.Column<long>(type: "bigint", nullable: true),
                    PrimaryAdminId = table.Column<long>(type: "bigint", nullable: true),
                    HospitalAddressId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hospital", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hospital_Address_HospitalAddressId",
                        column: x => x.HospitalAddressId,
                        principalTable: "Address",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Hospital_Employee_PrimaryAdminId",
                        column: x => x.PrimaryAdminId,
                        principalTable: "Employee",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StateProvince",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Abbr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedTimestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedTimestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CountryId = table.Column<long>(type: "bigint", nullable: true),
                    StateHospitalsId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StateProvince", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StateProvince_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StateProvince_Hospital_StateHospitalsId",
                        column: x => x.StateHospitalsId,
                        principalTable: "Hospital",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Region",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedTimestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedTimestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StateProvinceId = table.Column<long>(type: "bigint", nullable: true),
                    StateProvincesId = table.Column<int>(type: "int", nullable: true),
                    PrimaryAdminId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Region", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Region_Employee_PrimaryAdminId",
                        column: x => x.PrimaryAdminId,
                        principalTable: "Employee",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Region_StateProvince_StateProvincesId",
                        column: x => x.StateProvincesId,
                        principalTable: "StateProvince",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_EmployeeId",
                table: "Address",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_EmployeeNameId",
                table: "Employee",
                column: "EmployeeNameId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_HCPId",
                table: "Employee",
                column: "HCPId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_HCPId1",
                table: "Employee",
                column: "HCPId1");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_HomeAddressId",
                table: "Employee",
                column: "HomeAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_HospitalId",
                table: "Employee",
                column: "HospitalId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_RegionId",
                table: "Employee",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_WorkAddressId",
                table: "Employee",
                column: "WorkAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_HCP_HCPAddressId",
                table: "HCP",
                column: "HCPAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_HCP_HCPRegionIdId",
                table: "HCP",
                column: "HCPRegionIdId");

            migrationBuilder.CreateIndex(
                name: "IX_HCP_PrimaryAdminId",
                table: "HCP",
                column: "PrimaryAdminId");

            migrationBuilder.CreateIndex(
                name: "IX_HCP_PrimaryInformationAnalystId",
                table: "HCP",
                column: "PrimaryInformationAnalystId");

            migrationBuilder.CreateIndex(
                name: "IX_Hospital_HospitalAddressId",
                table: "Hospital",
                column: "HospitalAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Hospital_PrimaryAdminId",
                table: "Hospital",
                column: "PrimaryAdminId");

            migrationBuilder.CreateIndex(
                name: "IX_Hospital_RegionId",
                table: "Hospital",
                column: "RegionId",
                unique: true,
                filter: "[RegionId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Region_PrimaryAdminId",
                table: "Region",
                column: "PrimaryAdminId");

            migrationBuilder.CreateIndex(
                name: "IX_Region_StateProvincesId",
                table: "Region",
                column: "StateProvincesId");

            migrationBuilder.CreateIndex(
                name: "IX_StateProvince_CountryId",
                table: "StateProvince",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_StateProvince_StateHospitalsId",
                table: "StateProvince",
                column: "StateHospitalsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Employee_EmployeeId",
                table: "Address",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_HCP_HCPId",
                table: "Employee",
                column: "HCPId",
                principalTable: "HCP",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_HCP_HCPId1",
                table: "Employee",
                column: "HCPId1",
                principalTable: "HCP",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Hospital_HospitalId",
                table: "Employee",
                column: "HospitalId",
                principalTable: "Hospital",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Region_RegionId",
                table: "Employee",
                column: "RegionId",
                principalTable: "Region",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HCP_Region_HCPRegionIdId",
                table: "HCP",
                column: "HCPRegionIdId",
                principalTable: "Region",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Hospital_Region_RegionId",
                table: "Hospital",
                column: "RegionId",
                principalTable: "Region",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Employee_EmployeeId",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_HCP_Employee_PrimaryAdminId",
                table: "HCP");

            migrationBuilder.DropForeignKey(
                name: "FK_HCP_Employee_PrimaryInformationAnalystId",
                table: "HCP");

            migrationBuilder.DropForeignKey(
                name: "FK_Hospital_Employee_PrimaryAdminId",
                table: "Hospital");

            migrationBuilder.DropForeignKey(
                name: "FK_Region_Employee_PrimaryAdminId",
                table: "Region");

            migrationBuilder.DropForeignKey(
                name: "FK_Hospital_Address_HospitalAddressId",
                table: "Hospital");

            migrationBuilder.DropForeignKey(
                name: "FK_StateProvince_Hospital_StateHospitalsId",
                table: "StateProvince");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "HCP");

            migrationBuilder.DropTable(
                name: "PersonName");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Hospital");

            migrationBuilder.DropTable(
                name: "Region");

            migrationBuilder.DropTable(
                name: "StateProvince");

            migrationBuilder.DropTable(
                name: "Country");
        }
    }
}
