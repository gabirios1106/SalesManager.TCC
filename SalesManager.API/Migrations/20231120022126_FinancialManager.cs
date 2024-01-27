using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalesManager.API.Migrations
{
    /// <inheritdoc />
    public partial class FinancialManager : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AllLossOrExpenseOfMoney",
                table: "FinancialManager",
                newName: "ProfitOfProduct");

            migrationBuilder.RenameColumn(
                name: "AllGainOfSales",
                table: "FinancialManager",
                newName: "LossOrExpenseOfProduct");

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
                name: "GainSalesOfProduct",
                table: "FinancialManager",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AllExpense",
                table: "FinancialManager");

            migrationBuilder.DropColumn(
                name: "AllGain",
                table: "FinancialManager");

            migrationBuilder.DropColumn(
                name: "GainSalesOfProduct",
                table: "FinancialManager");

            migrationBuilder.RenameColumn(
                name: "ProfitOfProduct",
                table: "FinancialManager",
                newName: "AllLossOrExpenseOfMoney");

            migrationBuilder.RenameColumn(
                name: "LossOrExpenseOfProduct",
                table: "FinancialManager",
                newName: "AllGainOfSales");
        }
    }
}
