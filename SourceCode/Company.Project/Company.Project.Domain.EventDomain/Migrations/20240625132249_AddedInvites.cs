using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Company.Project.EventDomain.Migrations
{
    /// <inheritdoc />
    public partial class AddedInvites : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Invites",
                table: "Events",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Invites",
                table: "Events");
        }
    }
}
