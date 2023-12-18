using Microsoft.EntityFrameworkCore.Migrations;
using YaqeenDAL.Model;

#nullable disable

namespace YaqeenDAL.Migrations
{
    /// <inheritdoc />
    public partial class contenttypeenums : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Phase>(
                name: "Phase",
                table: "Contents",
                type: "phase",
                nullable: false,
                defaultValue: Phase.Draft);

            migrationBuilder.AddColumn<ContentType>(
                name: "Type",
                table: "Contents",
                type: "content_type",
                nullable: false,
                defaultValue: ContentType.Category);

            migrationBuilder.AddColumn<Visibility>(
                name: "Visibility",
                table: "Contents",
                type: "visibility",
                nullable: false,
                defaultValue: Visibility.Public);

            migrationBuilder.CreateIndex(
                name: "IX_Contents_Type",
                table: "Contents",
                column: "Type");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Contents_Type",
                table: "Contents");

            migrationBuilder.DropColumn(
                name: "Phase",
                table: "Contents");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Contents");

            migrationBuilder.DropColumn(
                name: "Visibility",
                table: "Contents");
        }
    }
}
