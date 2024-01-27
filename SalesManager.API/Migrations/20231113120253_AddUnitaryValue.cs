using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalesManager.API.Migrations
{
    /// <inheritdoc />
    public partial class AddUnitaryValue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductPrice",
                table: "StockMovement");

            migrationBuilder.AddColumn<double>(
                name: "UnitaryValue",
                table: "Product",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UnitaryValue",
                table: "Product");

            migrationBuilder.AddColumn<int>(
                name: "ProductPrice",
                table: "StockMovement",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
