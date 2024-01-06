using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace YaqeenDAL.Migrations
{
    /// <inheritdoc />
    public partial class bookmarkingapi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookmarks_Articles_ArticleId",
                table: "Bookmarks");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookmarks_Doctors_UserId",
                table: "Bookmarks");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookmarks_Patients_UserId",
                table: "Bookmarks");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Patients_PatientUserId",
                table: "Questions");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropIndex(
                name: "IX_Questions_PatientUserId",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Bookmarks_ArticleId",
                table: "Bookmarks");

            migrationBuilder.DropColumn(
                name: "PatientUserId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "ArticleId",
                table: "Bookmarks");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Bookmarks");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Bookmarks",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<int>(
                name: "ContentId",
                table: "Bookmarks",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Bookmarks_ContentId",
                table: "Bookmarks",
                column: "ContentId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookmarks_Contents_ContentId",
                table: "Bookmarks",
                column: "ContentId",
                principalTable: "Contents",
                principalColumn: "ContentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookmarks_Users_UserId",
                table: "Bookmarks",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookmarks_Contents_ContentId",
                table: "Bookmarks");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookmarks_Users_UserId",
                table: "Bookmarks");

            migrationBuilder.DropIndex(
                name: "IX_Bookmarks_ContentId",
                table: "Bookmarks");

            migrationBuilder.DropColumn(
                name: "ContentId",
                table: "Bookmarks");

            migrationBuilder.AddColumn<string>(
                name: "PatientUserId",
                table: "Questions",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Bookmarks",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ArticleId",
                table: "Bookmarks",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Bookmarks",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    ArticleId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    Category = table.Column<string>(type: "text", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Title = table.Column<string>(type: "text", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.ArticleId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Questions_PatientUserId",
                table: "Questions",
                column: "PatientUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookmarks_ArticleId",
                table: "Bookmarks",
                column: "ArticleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookmarks_Articles_ArticleId",
                table: "Bookmarks",
                column: "ArticleId",
                principalTable: "Articles",
                principalColumn: "ArticleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookmarks_Doctors_UserId",
                table: "Bookmarks",
                column: "UserId",
                principalTable: "Doctors",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookmarks_Patients_UserId",
                table: "Bookmarks",
                column: "UserId",
                principalTable: "Patients",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Patients_PatientUserId",
                table: "Questions",
                column: "PatientUserId",
                principalTable: "Patients",
                principalColumn: "UserId");
        }
    }
}
