using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace YaqeenDAL.Migrations
{
    /// <inheritdoc />
    public partial class refactortranslations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResourceLocalization_Interests_InterestId",
                table: "ResourceLocalization");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ResourceLocalization",
                table: "ResourceLocalization");

            migrationBuilder.DropIndex(
                name: "IX_ResourceLocalization_InterestId",
                table: "ResourceLocalization");

            migrationBuilder.DropColumn(
                name: "InterestId",
                table: "ResourceLocalization");

            migrationBuilder.AlterColumn<int>(
                name: "TranslationId",
                table: "ResourceLocalization",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "TranslationId",
                table: "Interests",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ResourceLocalization",
                table: "ResourceLocalization",
                columns: new[] { "TranslationId", "Language" });

            migrationBuilder.AddForeignKey(
                name: "FK_ResourceLocalization_Interests_TranslationId",
                table: "ResourceLocalization",
                column: "TranslationId",
                principalTable: "Interests",
                principalColumn: "InterestId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResourceLocalization_Interests_TranslationId",
                table: "ResourceLocalization");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ResourceLocalization",
                table: "ResourceLocalization");

            migrationBuilder.DropColumn(
                name: "TranslationId",
                table: "Interests");

            migrationBuilder.AlterColumn<int>(
                name: "TranslationId",
                table: "ResourceLocalization",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "InterestId",
                table: "ResourceLocalization",
                type: "integer",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ResourceLocalization",
                table: "ResourceLocalization",
                column: "TranslationId");

            migrationBuilder.CreateIndex(
                name: "IX_ResourceLocalization_InterestId",
                table: "ResourceLocalization",
                column: "InterestId");

            migrationBuilder.AddForeignKey(
                name: "FK_ResourceLocalization_Interests_InterestId",
                table: "ResourceLocalization",
                column: "InterestId",
                principalTable: "Interests",
                principalColumn: "InterestId");
        }
    }
}
