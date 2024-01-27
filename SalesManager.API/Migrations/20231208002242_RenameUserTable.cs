using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalesManager.API.Migrations
{
    /// <inheritdoc />
    public partial class RenameUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Client_Register_UserId",
                table: "Client");

            migrationBuilder.DropForeignKey(
                name: "FK_Department_Register_UserId",
                table: "Department");

            migrationBuilder.DropForeignKey(
                name: "FK_FinancialManager_Register_UserId",
                table: "FinancialManager");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Register_UserId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_StockMovement_Register_UserId",
                table: "StockMovement");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Register",
                table: "Register");

            migrationBuilder.RenameTable(
                name: "Register",
                newName: "User");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Client_User_UserId",
                table: "Client",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Department_User_UserId",
                table: "Department",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FinancialManager_User_UserId",
                table: "FinancialManager",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_User_UserId",
                table: "Product",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StockMovement_User_UserId",
                table: "StockMovement",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Client_User_UserId",
                table: "Client");

            migrationBuilder.DropForeignKey(
                name: "FK_Department_User_UserId",
                table: "Department");

            migrationBuilder.DropForeignKey(
                name: "FK_FinancialManager_User_UserId",
                table: "FinancialManager");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_User_UserId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_StockMovement_User_UserId",
                table: "StockMovement");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Register");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Register",
                table: "Register",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Client_Register_UserId",
                table: "Client",
                column: "UserId",
                principalTable: "Register",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Department_Register_UserId",
                table: "Department",
                column: "UserId",
                principalTable: "Register",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FinancialManager_Register_UserId",
                table: "FinancialManager",
                column: "UserId",
                principalTable: "Register",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Register_UserId",
                table: "Product",
                column: "UserId",
                principalTable: "Register",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StockMovement_Register_UserId",
                table: "StockMovement",
                column: "UserId",
                principalTable: "Register",
                principalColumn: "Id");
        }
    }
}
