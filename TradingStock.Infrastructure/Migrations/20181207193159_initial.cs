using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TradingStock.Infrastructure.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StockEvents",
                columns: table => new
                {
                    AggregateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EventId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EventType = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    Version = table.Column<int>(type: "int", nullable: false),
                    TimeStamp = table.Column<DateTimeOffset>(type: "datetimeoffset(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockEvents", x => x.AggregateId);
                });

            migrationBuilder.CreateTable(
                name: "Stocks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Version = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    StockType = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Up = table.Column<double>(type: "float", nullable: true),
                    Down = table.Column<double>(type: "float", nullable: true),
                    StockChange = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StockEvents");

            migrationBuilder.DropTable(
                name: "Stocks");
        }
    }
}
