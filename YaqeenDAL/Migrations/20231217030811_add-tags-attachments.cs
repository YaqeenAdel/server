using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using YaqeenDAL.Model;

#nullable disable

namespace YaqeenDAL.Migrations
{
    /// <inheritdoc />
    public partial class addtagsattachments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Attachment>(
                name: "Attachments",
                table: "Contents",
                type: "jsonb",
                nullable: false);

            migrationBuilder.AddColumn<Dictionary<string, string>>(
                name: "Tags",
                table: "Contents",
                type: "jsonb",
                nullable: false);

            migrationBuilder.CreateIndex(
                name: "IX_Contents_Tags",
                table: "Contents",
                column: "Tags");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Contents_Tags",
                table: "Contents");

            migrationBuilder.DropColumn(
                name: "Attachments",
                table: "Contents");

            migrationBuilder.DropColumn(
                name: "Tags",
                table: "Contents");
        }
    }
}
