using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalesManager.API.Migrations
{
    /// <inheritdoc />
    public partial class ExcludRowsAllGain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AllExpense",
                table: "FinancialManager");

            migrationBuilder.DropColumn(
                name: "AllGain",
                table: "FinancialManager");

            migrationBuilder.DropColumn(
                name: "AllProfit",
                table: "FinancialManager");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "AllExpense",
                table: "FinancialManager",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "AllGain",
                table: "FinancialManager",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "AllProfit",
                table: "FinancialManager",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
