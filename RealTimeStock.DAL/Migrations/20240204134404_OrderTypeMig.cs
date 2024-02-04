using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RealTimeStock.DAL.Migrations
{
    /// <inheritdoc />
    public partial class OrderTypeMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_OrderType_TypeId",
                table: "Order");

            migrationBuilder.RenameColumn(
                name: "TypeId",
                table: "Order",
                newName: "OrderTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_TypeId",
                table: "Order",
                newName: "IX_Order_OrderTypeId");

            migrationBuilder.InsertData(
                table: "Stock",
                columns: new[] { "Symbol", "Price", "TimeStamps" },
                values: new object[,]
                {
                    { "AAPL", 22.0, new DateTime(2024, 2, 4, 15, 44, 3, 788, DateTimeKind.Local).AddTicks(2154) },
                    { "AMZN", 55.0, new DateTime(2024, 2, 4, 15, 44, 3, 788, DateTimeKind.Local).AddTicks(2236) },
                    { "GOOGL", 33.0, new DateTime(2024, 2, 4, 15, 44, 3, 788, DateTimeKind.Local).AddTicks(2228) },
                    { "MSFT", 44.0, new DateTime(2024, 2, 4, 15, 44, 3, 788, DateTimeKind.Local).AddTicks(2232) },
                    { "TSLA", 66.0, new DateTime(2024, 2, 4, 15, 44, 3, 788, DateTimeKind.Local).AddTicks(2239) }
                });

            migrationBuilder.InsertData(
                table: "History",
                columns: new[] { "Id", "Price", "StockSymbol", "TimeStamps" },
                values: new object[,]
                {
                    { 1, 22.0, "AAPL", new DateTime(2024, 2, 4, 15, 44, 3, 788, DateTimeKind.Local).AddTicks(2291) },
                    { 2, 33.0, "GOOGL", new DateTime(2024, 2, 4, 15, 44, 3, 788, DateTimeKind.Local).AddTicks(2304) },
                    { 3, 44.0, "MSFT", new DateTime(2024, 2, 4, 15, 44, 3, 788, DateTimeKind.Local).AddTicks(2308) },
                    { 4, 55.0, "AMZN", new DateTime(2024, 2, 4, 15, 44, 3, 788, DateTimeKind.Local).AddTicks(2317) },
                    { 5, 66.0, "TSLA", new DateTime(2024, 2, 4, 15, 44, 3, 788, DateTimeKind.Local).AddTicks(2321) }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Order_OrderType_OrderTypeId",
                table: "Order",
                column: "OrderTypeId",
                principalTable: "OrderType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_OrderType_OrderTypeId",
                table: "Order");

            migrationBuilder.DeleteData(
                table: "History",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "History",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "History",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "History",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "History",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Stock",
                keyColumn: "Symbol",
                keyValue: "AAPL");

            migrationBuilder.DeleteData(
                table: "Stock",
                keyColumn: "Symbol",
                keyValue: "AMZN");

            migrationBuilder.DeleteData(
                table: "Stock",
                keyColumn: "Symbol",
                keyValue: "GOOGL");

            migrationBuilder.DeleteData(
                table: "Stock",
                keyColumn: "Symbol",
                keyValue: "MSFT");

            migrationBuilder.DeleteData(
                table: "Stock",
                keyColumn: "Symbol",
                keyValue: "TSLA");

            migrationBuilder.RenameColumn(
                name: "OrderTypeId",
                table: "Order",
                newName: "TypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_OrderTypeId",
                table: "Order",
                newName: "IX_Order_TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_OrderType_TypeId",
                table: "Order",
                column: "TypeId",
                principalTable: "OrderType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
