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
                name: "FK_ResourceLocalization_CancerStages_CancerStageStageId",
                table: "ResourceLocalization");

            migrationBuilder.DropForeignKey(
                name: "FK_ResourceLocalization_CancerTypes_CancerTypeCancerId",
                table: "ResourceLocalization");

            migrationBuilder.DropForeignKey(
                name: "FK_ResourceLocalization_Interests_InterestId",
                table: "ResourceLocalization");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ResourceLocalization",
                table: "ResourceLocalization");

            migrationBuilder.DropIndex(
                name: "IX_ResourceLocalization_CancerStageStageId",
                table: "ResourceLocalization");

            migrationBuilder.DropIndex(
                name: "IX_ResourceLocalization_CancerTypeCancerId",
                table: "ResourceLocalization");

            migrationBuilder.DropIndex(
                name: "IX_ResourceLocalization_InterestId",
                table: "ResourceLocalization");

            migrationBuilder.DropColumn(
                name: "CancerStageStageId",
                table: "ResourceLocalization");

            migrationBuilder.DropColumn(
                name: "CancerTypeCancerId",
                table: "ResourceLocalization");

            migrationBuilder.DropColumn(
                name: "InterestId",
                table: "ResourceLocalization");

            migrationBuilder.RenameTable(
                name: "ResourceLocalization",
                newName: "ResourceLocalizations");

            migrationBuilder.AddColumn<int>(
                name: "TranslationId",
                table: "Interests",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TranslationId",
                table: "CancerTypes",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TranslationId",
                table: "CancerStages",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TranslationId",
                table: "ResourceLocalizations",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ResourceLocalizations",
                table: "ResourceLocalizations",
                columns: new[] { "TranslationId", "Language" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ResourceLocalizations",
                table: "ResourceLocalizations");

            migrationBuilder.DropColumn(
                name: "TranslationId",
                table: "Interests");

            migrationBuilder.DropColumn(
                name: "TranslationId",
                table: "CancerTypes");

            migrationBuilder.DropColumn(
                name: "TranslationId",
                table: "CancerStages");

            migrationBuilder.RenameTable(
                name: "ResourceLocalizations",
                newName: "ResourceLocalization");

            migrationBuilder.AlterColumn<int>(
                name: "TranslationId",
                table: "ResourceLocalization",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "CancerStageStageId",
                table: "ResourceLocalization",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CancerTypeCancerId",
                table: "ResourceLocalization",
                type: "integer",
                nullable: true);

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
                name: "IX_ResourceLocalization_CancerStageStageId",
                table: "ResourceLocalization",
                column: "CancerStageStageId");

            migrationBuilder.CreateIndex(
                name: "IX_ResourceLocalization_CancerTypeCancerId",
                table: "ResourceLocalization",
                column: "CancerTypeCancerId");

            migrationBuilder.CreateIndex(
                name: "IX_ResourceLocalization_InterestId",
                table: "ResourceLocalization",
                column: "InterestId");

            migrationBuilder.AddForeignKey(
                name: "FK_ResourceLocalization_CancerStages_CancerStageStageId",
                table: "ResourceLocalization",
                column: "CancerStageStageId",
                principalTable: "CancerStages",
                principalColumn: "StageId");

            migrationBuilder.AddForeignKey(
                name: "FK_ResourceLocalization_CancerTypes_CancerTypeCancerId",
                table: "ResourceLocalization",
                column: "CancerTypeCancerId",
                principalTable: "CancerTypes",
                principalColumn: "CancerId");

            migrationBuilder.AddForeignKey(
                name: "FK_ResourceLocalization_Interests_InterestId",
                table: "ResourceLocalization",
                column: "InterestId",
                principalTable: "Interests",
                principalColumn: "InterestId");
        }
    }
}
