using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PayRollAnalzyser.Migrations
{
    /// <inheritdoc />
    public partial class AddPayrollNavigation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalGrossPay",
                table: "Payrolls");

            migrationBuilder.CreateIndex(
                name: "IX_Payrolls_EmployeeId",
                table: "Payrolls",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payrolls_Employees_EmployeeId",
                table: "Payrolls",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payrolls_Employees_EmployeeId",
                table: "Payrolls");

            migrationBuilder.DropIndex(
                name: "IX_Payrolls_EmployeeId",
                table: "Payrolls");

            migrationBuilder.AddColumn<decimal>(
                name: "TotalGrossPay",
                table: "Payrolls",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
