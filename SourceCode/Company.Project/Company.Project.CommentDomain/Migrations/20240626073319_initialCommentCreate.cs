using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Company.Project.CommentDomain.Migrations
{
    /// <inheritdoc />
    public partial class initialCommentCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EventId = table.Column<int>(type: "int", nullable: false),
                    GUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOnDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModifiedOnDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedByUserID = table.Column<int>(type: "int", nullable: false),
                    ModifiedByUserID = table.Column<int>(type: "int", nullable: false),
                    Version = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Event_key", 
                        column: x => x.EventId,
                        principalTable:"Events",
                        principalColumn:"Id",
                        onDelete: ReferentialAction.Cascade
                        );
                    /*table.ForeignKey(
                        name: "FK_Comment_Event_User_key",
                        column: x => x.UserId,
                        principalTable: "Events",
                        principalColumn:"UserEmailId",
                        onDelete: ReferentialAction.Cascade
                        );*/
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");
        }
    }
}
