using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YaqeenDAL.Migrations
{
    /// <inheritdoc />
    public partial class bookmarkapi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Bookmarks_ContentId",
                table: "Bookmarks");

            migrationBuilder.DropIndex(
                name: "IX_Bookmarks_UserId_ContentId",
                table: "Bookmarks");

            migrationBuilder.CreateIndex(
                name: "IX_Bookmarks_ContentId",
                table: "Bookmarks",
                column: "ContentId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookmarks_UserId_ContentId",
                table: "Bookmarks",
                columns: new[] { "UserId", "ContentId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Bookmarks_ContentId",
                table: "Bookmarks");

            migrationBuilder.DropIndex(
                name: "IX_Bookmarks_UserId_ContentId",
                table: "Bookmarks");

            migrationBuilder.CreateIndex(
                name: "IX_Bookmarks_ContentId",
                table: "Bookmarks",
                column: "ContentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bookmarks_UserId_ContentId",
                table: "Bookmarks",
                columns: new[] { "UserId", "ContentId" });
        }
    }
}
