using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YaqeenApi.Migrations
{
    /// <inheritdoc />
    public partial class dockerimage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IdpUserIdentifier",
                table: "Users",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdpUserIdentifier",
                table: "Users");
        }
    }
}
