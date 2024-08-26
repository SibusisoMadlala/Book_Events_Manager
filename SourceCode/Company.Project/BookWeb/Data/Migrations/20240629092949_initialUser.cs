using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookWeb.Data.Migrations
{
    /// <inheritdoc />
    public partial class initialUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "08230961-9f8a-41bb-925c-87bb50fd389f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fa6395e4-d13f-402a-bf18-116e3eb7b34e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "175766d5-1f8f-4d52-a770-1b75e90848b4", null, "admin", "admin" },
                    { "ce356194-2fd2-4ce5-a228-14e62663c8bb", null, "normalUser", "normalUser" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "08230961-9f8a-41bb-925c-87bb50fd389f", null, "admin", "admin" },
                    { "fa6395e4-d13f-402a-bf18-116e3eb7b34e", null, "normalUser", "normalUser" }
                });
        }
    }
}
