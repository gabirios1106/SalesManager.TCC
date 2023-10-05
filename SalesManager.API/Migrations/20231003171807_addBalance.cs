using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalesManager.API.Migrations
{
    /// <inheritdoc />
    public partial class addBalance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BalanceStock",
                table: "Product",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BalanceStock",
                table: "Product");
        }
    }
}
