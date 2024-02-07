using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YaqeenDAL.Migrations
{
    /// <inheritdoc />
    public partial class contentinterestmanytomany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InterestIDs",
                table: "Contents");

            migrationBuilder.CreateTable(
                name: "ContentInterest",
                columns: table => new
                {
                    ContentsContentId = table.Column<int>(type: "integer", nullable: false),
                    InterestsInterestId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentInterest", x => new { x.ContentsContentId, x.InterestsInterestId });
                    table.ForeignKey(
                        name: "FK_ContentInterest_Contents_ContentsContentId",
                        column: x => x.ContentsContentId,
                        principalTable: "Contents",
                        principalColumn: "ContentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContentInterest_Interests_InterestsInterestId",
                        column: x => x.InterestsInterestId,
                        principalTable: "Interests",
                        principalColumn: "InterestId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContentInterest_InterestsInterestId",
                table: "ContentInterest",
                column: "InterestsInterestId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContentInterest");

            migrationBuilder.AddColumn<int[]>(
                name: "InterestIDs",
                table: "Contents",
                type: "integer[]",
                nullable: true);
        }
    }
}
