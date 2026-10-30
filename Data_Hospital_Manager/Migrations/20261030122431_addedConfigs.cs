using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data_Hospital_Manager.Migrations
{
    /// <inheritdoc />
    public partial class addedConfigs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Hospitals",
                columns: new[] { "Id", "Address", "BedsCount", "CreatedOn", "Email", "IsDeleted", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "123 Main St, Kazanlak", 200, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "hospital@kazanlak.com", false, "Kazanlak Hospital", "1234567890" },
                    { 2, "123 Main St, Sofia", 200, new DateTime(2026, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "hospital@sofia.com", false, "Sofia Hospital", "1234567990" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
