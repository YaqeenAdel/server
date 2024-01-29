using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YaqeenDAL.Migrations
{
    /// <inheritdoc />
    public partial class fixtranslationidtype1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TranslationId",
                table: "SymptomLookups");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TranslationId",
                table: "SymptomLookups",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
