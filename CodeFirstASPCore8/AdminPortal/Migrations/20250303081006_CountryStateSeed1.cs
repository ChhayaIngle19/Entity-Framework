using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdminPortal.Migrations
{
    /// <inheritdoc />
    public partial class CountryStateSeed1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "StateProvince",
                newName: "StateProvinceId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Country",
                newName: "CountryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StateProvinceId",
                table: "StateProvince",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CountryId",
                table: "Country",
                newName: "Id");
        }
    }
}
