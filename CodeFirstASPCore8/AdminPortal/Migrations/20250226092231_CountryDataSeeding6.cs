using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdminPortal.Migrations
{
    /// <inheritdoc />
    public partial class CountryDataSeeding6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Abbr",
                table: "Country",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Country_Abbr",
                table: "Country",
                column: "Abbr",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Country_Abbr",
                table: "Country");

            migrationBuilder.AlterColumn<string>(
                name: "Abbr",
                table: "Country",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);
        }
    }
}
