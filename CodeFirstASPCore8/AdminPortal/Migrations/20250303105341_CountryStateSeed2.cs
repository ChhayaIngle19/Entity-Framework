using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdminPortal.Migrations
{
    /// <inheritdoc />
    public partial class CountryStateSeed2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StateProvince_Country_CountryId",
                table: "StateProvince");

            migrationBuilder.AlterColumn<long>(
                name: "CountryId",
                table: "StateProvince",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Abbr",
                table: "StateProvince",
                type: "nvarchar(6)",
                maxLength: 6,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(6)",
                oldMaxLength: 6,
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_StateProvince_Country_CountryId",
                table: "StateProvince",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "CountryId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StateProvince_Country_CountryId",
                table: "StateProvince");

            migrationBuilder.AlterColumn<long>(
                name: "CountryId",
                table: "StateProvince",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<string>(
                name: "Abbr",
                table: "StateProvince",
                type: "nvarchar(6)",
                maxLength: 6,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(6)",
                oldMaxLength: 6);

            migrationBuilder.AddForeignKey(
                name: "FK_StateProvince_Country_CountryId",
                table: "StateProvince",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "CountryId");
        }
    }
}
