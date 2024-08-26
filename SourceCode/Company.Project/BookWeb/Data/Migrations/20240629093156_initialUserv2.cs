using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookWeb.Data.Migrations
{
    /// <inheritdoc />
    public partial class initialUserv2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "175766d5-1f8f-4d52-a770-1b75e90848b4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ce356194-2fd2-4ce5-a228-14e62663c8bb");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "ce59ad3f-dd51-46ac-98ea-16cc5034470b", null, "normalUser", "normalUser" },
                    { "d9205cf7-a86c-4fc0-b32e-5162b6eb000a", null, "admin", "admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ce59ad3f-dd51-46ac-98ea-16cc5034470b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d9205cf7-a86c-4fc0-b32e-5162b6eb000a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "175766d5-1f8f-4d52-a770-1b75e90848b4", null, "admin", "admin" },
                    { "ce356194-2fd2-4ce5-a228-14e62663c8bb", null, "normalUser", "normalUser" }
                });
        }
    }
}
