using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalesManager.API.Migrations
{
    /// <inheritdoc />
    public partial class User : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "registerId",
                table: "StockMovement");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Register");

            migrationBuilder.DropColumn(
                name: "registerId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "registerId",
                table: "FinancialManager");

            migrationBuilder.DropColumn(
                name: "registerId",
                table: "Department");

            migrationBuilder.DropColumn(
                name: "registerId",
                table: "Client");

            migrationBuilder.CreateIndex(
                name: "IX_StockMovement_UserId",
                table: "StockMovement",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_UserId",
                table: "Product",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FinancialManager_UserId",
                table: "FinancialManager",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Department_UserId",
                table: "Department",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Client_UserId",
                table: "Client",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Client_Register_UserId",
                table: "Client",
                column: "UserId",
                principalTable: "Register",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Department_Register_UserId",
                table: "Department",
                column: "UserId",
                principalTable: "Register",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FinancialManager_Register_UserId",
                table: "FinancialManager",
                column: "UserId",
                principalTable: "Register",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Register_UserId",
                table: "Product",
                column: "UserId",
                principalTable: "Register",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StockMovement_Register_UserId",
                table: "StockMovement",
                column: "UserId",
                principalTable: "Register",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropIndex(
                name: "IX_StockMovement_UserId",
                table: "StockMovement");

            migrationBuilder.DropIndex(
                name: "IX_Product_UserId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_FinancialManager_UserId",
                table: "FinancialManager");

            migrationBuilder.DropIndex(
                name: "IX_Department_UserId",
                table: "Department");

            migrationBuilder.DropIndex(
                name: "IX_Client_UserId",
                table: "Client");

            migrationBuilder.AddColumn<int>(
                name: "registerId",
                table: "StockMovement",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Register",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "registerId",
                table: "Product",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "registerId",
                table: "FinancialManager",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "registerId",
                table: "Department",
                type: "INTEGER",
                nullable: true);

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
    }
}
