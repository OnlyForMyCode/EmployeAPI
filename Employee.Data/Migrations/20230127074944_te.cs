using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Employee.Data.Migrations
{
    /// <inheritdoc />
    public partial class te : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2023, 1, 27, 8, 49, 44, 274, DateTimeKind.Local).AddTicks(2438));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2023, 1, 27, 8, 49, 44, 274, DateTimeKind.Local).AddTicks(2478));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: null);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: null);
        }
    }
}
