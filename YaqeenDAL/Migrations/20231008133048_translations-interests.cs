using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace YaqeenDAL.Migrations
{
    /// <inheritdoc />
    public partial class translationsinterests : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TargetUserType",
                table: "Interests",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ResourceLocalization",
                columns: table => new
                {
                    TranslationId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TableName = table.Column<string>(type: "text", nullable: false),
                    Language = table.Column<string>(type: "text", nullable: false),
                    Translation = table.Column<Dictionary<string, string>>(type: "jsonb", nullable: false),
                    CancerStageStageId = table.Column<int>(type: "integer", nullable: true),
                    CancerTypeCancerId = table.Column<int>(type: "integer", nullable: true),
                    InterestId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceLocalization", x => x.TranslationId);
                    table.ForeignKey(
                        name: "FK_ResourceLocalization_CancerStages_CancerStageStageId",
                        column: x => x.CancerStageStageId,
                        principalTable: "CancerStages",
                        principalColumn: "StageId");
                    table.ForeignKey(
                        name: "FK_ResourceLocalization_CancerTypes_CancerTypeCancerId",
                        column: x => x.CancerTypeCancerId,
                        principalTable: "CancerTypes",
                        principalColumn: "CancerId");
                    table.ForeignKey(
                        name: "FK_ResourceLocalization_Interests_InterestId",
                        column: x => x.InterestId,
                        principalTable: "Interests",
                        principalColumn: "InterestId");
                });

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ResourceLocalization");

            migrationBuilder.DropColumn(
                name: "TargetUserType",
                table: "Interests");
        }
    }
}
