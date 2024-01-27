using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalesManager.API.Migrations
{
    /// <inheritdoc />
    public partial class AddUserId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "StockMovement",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "registerId",
                table: "StockMovement",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Product",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "registerId",
                table: "Product",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "FinancialManager",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "registerId",
                table: "FinancialManager",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Department",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "registerId",
                table: "Department",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Client",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "registerId",
                table: "Client",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StockMovement_registerId",
                table: "StockMovement",
                column: "registerId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_registerId",
                table: "Product",
                column: "registerId");

            migrationBuilder.CreateIndex(
                name: "IX_FinancialManager_registerId",
                table: "FinancialManager",
                column: "registerId");

            migrationBuilder.CreateIndex(
                name: "IX_Department_registerId",
                table: "Department",
                column: "registerId");

            migrationBuilder.CreateIndex(
                name: "IX_Client_registerId",
                table: "Client",
                column: "registerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Client_Register_registerId",
                table: "Client",
                column: "registerId",
                principalTable: "Register",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Department_Register_registerId",
                table: "Department",
                column: "registerId",
                principalTable: "Register",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FinancialManager_Register_registerId",
                table: "FinancialManager",
                column: "registerId",
                principalTable: "Register",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Register_registerId",
                table: "Product",
                column: "registerId",
                principalTable: "Register",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StockMovement_Register_registerId",
                table: "StockMovement",
                column: "registerId",
                principalTable: "Register",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Client_Register_registerId",
                table: "Client");

            migrationBuilder.DropForeignKey(
                name: "FK_Department_Register_registerId",
                table: "Department");

            migrationBuilder.DropForeignKey(
                name: "FK_FinancialManager_Register_registerId",
                table: "FinancialManager");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Register_registerId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_StockMovement_Register_registerId",
                table: "StockMovement");

            migrationBuilder.DropIndex(
                name: "IX_StockMovement_registerId",
                table: "StockMovement");

            migrationBuilder.DropIndex(
                name: "IX_Product_registerId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_FinancialManager_registerId",
                table: "FinancialManager");

            migrationBuilder.DropIndex(
                name: "IX_Department_registerId",
                table: "Department");

            migrationBuilder.DropIndex(
                name: "IX_Client_registerId",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "StockMovement");

            migrationBuilder.DropColumn(
                name: "registerId",
                table: "StockMovement");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "registerId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "FinancialManager");

            migrationBuilder.DropColumn(
                name: "registerId",
                table: "FinancialManager");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Department");

            migrationBuilder.DropColumn(
                name: "registerId",
                table: "Department");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "registerId",
                table: "Client");
        }
    }
}
