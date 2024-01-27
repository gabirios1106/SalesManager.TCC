using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalesManager.API.Migrations
{
    /// <inheritdoc />
    public partial class NewPageClients : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClientID",
                table: "StockMovement",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClientName = table.Column<string>(type: "TEXT", nullable: false),
                    ClientAddressState = table.Column<string>(type: "TEXT", nullable: false),
                    ClientAddressCity = table.Column<string>(type: "TEXT", nullable: false),
                    ClientCEP = table.Column<int>(type: "INTEGER", nullable: false),
                    ClientEmail = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StockMovement_ClientID",
                table: "StockMovement",
                column: "ClientID");

            migrationBuilder.AddForeignKey(
                name: "FK_StockMovement_Client_ClientID",
                table: "StockMovement",
                column: "ClientID",
                principalTable: "Client",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockMovement_Client_ClientID",
                table: "StockMovement");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropIndex(
                name: "IX_StockMovement_ClientID",
                table: "StockMovement");

            migrationBuilder.DropColumn(
                name: "ClientID",
                table: "StockMovement");
        }
    }
}
