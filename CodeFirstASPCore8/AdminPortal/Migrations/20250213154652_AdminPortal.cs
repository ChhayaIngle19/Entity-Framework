using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdminPortal.Migrations
{
    /// <inheritdoc />
    public partial class AdminPortal : Migration
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
                    Continent = table.Column<int>(type: "int", nullable: true),
                    CreatedTimestamp = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedTimestamp = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    TimeStamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    Prefix = table.Column<int>(type: "int", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Suffix = table.Column<int>(type: "int", nullable: true),
                    CreateTimeStamp = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTimeStamp = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                    TimeStamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    Line1 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Line2 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StateProvince = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ZipPinCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: true),
                    CreatedTimestamp = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedTimestamp = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EmployeeId = table.Column<long>(type: "bigint", nullable: true),
                    HCPId = table.Column<long>(type: "bigint", nullable: true),
                    HospitalId = table.Column<long>(type: "bigint", nullable: true),
                    EmployeeId1 = table.Column<long>(type: "bigint", nullable: true),
                    EmployeeId2 = table.Column<long>(type: "bigint", nullable: true)
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
                    TimeStamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: true),
                    Email_Work = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: true),
                    Email_Personal = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: true),
                    Mobile_Work = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Mobile_Personal = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    IsClinician = table.Column<bool>(type: "bit", nullable: false),
                    HireDate = table.Column<DateOnly>(type: "date", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedTimestamp = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedTimestamp = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EmployeeNameId = table.Column<long>(type: "bigint", nullable: false),
                    HCPId = table.Column<long>(type: "bigint", nullable: true),
                    HCPId1 = table.Column<long>(type: "bigint", nullable: true),
                    HospitalId = table.Column<long>(type: "bigint", nullable: true),
                    RegionId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employee_PersonName_EmployeeNameId",
                        column: x => x.EmployeeNameId,
                        principalTable: "PersonName",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HCP",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeStamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsRootUserIdEnabled = table.Column<bool>(type: "bit", nullable: true),
                    IsSecretKeyEnabled = table.Column<bool>(type: "bit", nullable: true),
                    IsLicenseKeyActivated = table.Column<bool>(type: "bit", nullable: true),
                    AreSecretQuestionsSetup = table.Column<bool>(type: "bit", nullable: true),
                    CreatedTimestamp = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedTimestamp = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EmployeeId = table.Column<long>(type: "bigint", nullable: true),
                    PrimaryInformationAnalystId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HCP", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HCP_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HCP_Employee_PrimaryInformationAnalystId",
                        column: x => x.PrimaryInformationAnalystId,
                        principalTable: "Employee",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Region",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeStamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    CreatedTimestamp = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedTimestamp = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HCPId = table.Column<long>(type: "bigint", nullable: true),
                    PrimaryAdminId = table.Column<long>(type: "bigint", nullable: true),
                    HCPId1 = table.Column<long>(type: "bigint", nullable: true)
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
                        name: "FK_Region_HCP_HCPId",
                        column: x => x.HCPId,
                        principalTable: "HCP",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Region_HCP_HCPId1",
                        column: x => x.HCPId1,
                        principalTable: "HCP",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StateProvince",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Abbr = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    CreatedTimestamp = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedTimestamp = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CountryId = table.Column<long>(type: "bigint", nullable: true),
                    RegionId = table.Column<long>(type: "bigint", nullable: true)
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
                        name: "FK_StateProvince_Region_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Region",
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
                    CreateTimestamp = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTimestamp = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RegionId = table.Column<long>(type: "bigint", nullable: true),
                    StateProvinceId = table.Column<long>(type: "bigint", nullable: true),
                    StateProvinceId1 = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hospital", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hospital_Employee_StateProvinceId",
                        column: x => x.StateProvinceId,
                        principalTable: "Employee",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Hospital_Region_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Region",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Hospital_StateProvince_StateProvinceId1",
                        column: x => x.StateProvinceId1,
                        principalTable: "StateProvince",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_EmployeeId",
                table: "Address",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_EmployeeId1",
                table: "Address",
                column: "EmployeeId1",
                unique: true,
                filter: "[EmployeeId1] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Address_EmployeeId2",
                table: "Address",
                column: "EmployeeId2",
                unique: true,
                filter: "[EmployeeId2] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Address_HCPId",
                table: "Address",
                column: "HCPId",
                unique: true,
                filter: "[HCPId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Address_HospitalId",
                table: "Address",
                column: "HospitalId",
                unique: true,
                filter: "[HospitalId] IS NOT NULL");

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
                name: "IX_Employee_HospitalId",
                table: "Employee",
                column: "HospitalId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_RegionId",
                table: "Employee",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_HCP_EmployeeId",
                table: "HCP",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_HCP_PrimaryInformationAnalystId",
                table: "HCP",
                column: "PrimaryInformationAnalystId");

            migrationBuilder.CreateIndex(
                name: "IX_Hospital_RegionId",
                table: "Hospital",
                column: "RegionId",
                unique: true,
                filter: "[RegionId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Hospital_StateProvinceId",
                table: "Hospital",
                column: "StateProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_Hospital_StateProvinceId1",
                table: "Hospital",
                column: "StateProvinceId1");

            migrationBuilder.CreateIndex(
                name: "IX_Region_HCPId",
                table: "Region",
                column: "HCPId");

            migrationBuilder.CreateIndex(
                name: "IX_Region_HCPId1",
                table: "Region",
                column: "HCPId1",
                unique: true,
                filter: "[HCPId1] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Region_PrimaryAdminId",
                table: "Region",
                column: "PrimaryAdminId");

            migrationBuilder.CreateIndex(
                name: "IX_StateProvince_CountryId",
                table: "StateProvince",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_StateProvince_RegionId",
                table: "StateProvince",
                column: "RegionId",
                unique: true,
                filter: "[RegionId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Employee_EmployeeId",
                table: "Address",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Employee_EmployeeId1",
                table: "Address",
                column: "EmployeeId1",
                principalTable: "Employee",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Employee_EmployeeId2",
                table: "Address",
                column: "EmployeeId2",
                principalTable: "Employee",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_HCP_HCPId",
                table: "Address",
                column: "HCPId",
                principalTable: "HCP",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Hospital_HospitalId",
                table: "Address",
                column: "HospitalId",
                principalTable: "Hospital",
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HCP_Employee_EmployeeId",
                table: "HCP");

            migrationBuilder.DropForeignKey(
                name: "FK_HCP_Employee_PrimaryInformationAnalystId",
                table: "HCP");

            migrationBuilder.DropForeignKey(
                name: "FK_Hospital_Employee_StateProvinceId",
                table: "Hospital");

            migrationBuilder.DropForeignKey(
                name: "FK_Region_Employee_PrimaryAdminId",
                table: "Region");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Hospital");

            migrationBuilder.DropTable(
                name: "PersonName");

            migrationBuilder.DropTable(
                name: "StateProvince");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "Region");

            migrationBuilder.DropTable(
                name: "HCP");
        }
    }
}
