using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalManagementCode.Migrations
{
    /// <inheritdoc />
    public partial class EmployeeData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_HCP_HCPId2",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_HCPId2",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "HCP",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "HCPId2",
                table: "Employee");

            migrationBuilder.AlterColumn<long>(
                name: "HCPId",
                table: "Employee",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_HCPId",
                table: "Employee",
                column: "HCPId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_HCP_HCPId",
                table: "Employee",
                column: "HCPId",
                principalTable: "HCP",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_HCP_HCPId",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_HCPId",
                table: "Employee");

            migrationBuilder.AlterColumn<int>(
                name: "HCPId",
                table: "Employee",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "HCP",
                table: "Employee",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "HCPId2",
                table: "Employee",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employee_HCPId2",
                table: "Employee",
                column: "HCPId2");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_HCP_HCPId2",
                table: "Employee",
                column: "HCPId2",
                principalTable: "HCP",
                principalColumn: "Id");
        }
    }
}
