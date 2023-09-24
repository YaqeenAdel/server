using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YaqeenApi.Migrations
{
    /// <inheritdoc />
    public partial class schemarelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AnswerId",
                table: "Doctors",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BookmarkId",
                table: "Doctors",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnswerId",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "BookmarkId",
                table: "Doctors");
        }
    }
}
