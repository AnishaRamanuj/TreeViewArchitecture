using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TreeViewArchitecture.Migrations
{
    /// <inheritdoc />
    public partial class seedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Nodes",
                columns: new[] { "NodeId", "IsActive", "NodeName", "ParentNodeId", "StartDate" },
                values: new object[,]
                {
                    { 1, true, "Node 1", 1, new DateTime(2024, 5, 25, 2, 30, 37, 622, DateTimeKind.Local).AddTicks(2947) },
                    { 2, true, "Node 2", 2, new DateTime(2024, 5, 25, 2, 30, 37, 622, DateTimeKind.Local).AddTicks(2961) },
                    { 3, false, "Node 3", 1, new DateTime(2024, 5, 25, 2, 30, 37, 622, DateTimeKind.Local).AddTicks(2963) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Nodes",
                keyColumn: "NodeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Nodes",
                keyColumn: "NodeId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Nodes",
                keyColumn: "NodeId",
                keyValue: 1);
        }
    }
}
