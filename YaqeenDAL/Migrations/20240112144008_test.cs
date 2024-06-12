using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YaqeenDAL.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Test",
                table: "Interests",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Bookmarks_UserId_ContentId",
                table: "Bookmarks",
                columns: new[] { "UserId", "ContentId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Bookmarks_UserId_ContentId",
                table: "Bookmarks");

            migrationBuilder.DropColumn(
                name: "Test",
                table: "Interests");
        }
    }
}
