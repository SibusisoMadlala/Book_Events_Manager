using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Company.Project.EventDomain.Migrations
{
    /// <inheritdoc />
    public partial class removed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Version",
                table: "Events");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Version",
                table: "Events",
                type: "rowversion",
                rowVersion: true,
                nullable: true);
        }
    }
}
