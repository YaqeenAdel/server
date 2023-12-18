using Microsoft.EntityFrameworkCore.Migrations;
using YaqeenDAL.Model;

#nullable disable

namespace YaqeenDAL.Migrations
{
    /// <inheritdoc />
    public partial class fixmigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:content_type", "category,question,answer,blood_donation")
                .Annotation("Npgsql:Enum:phase", "draft,published")
                .Annotation("Npgsql:Enum:user_type", "patient,doctor")
                .Annotation("Npgsql:Enum:verification_status", "pending,more_info_needed,approved,rejected")
                .Annotation("Npgsql:Enum:visibility", "public,private")
                .OldAnnotation("Npgsql:Enum:user_type", "patient,doctor")
                .OldAnnotation("Npgsql:Enum:verification_status", "pending,more_info_needed,approved,rejected");

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

            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:user_type", "patient,doctor")
                .Annotation("Npgsql:Enum:verification_status", "pending,more_info_needed,approved,rejected")
                .OldAnnotation("Npgsql:Enum:content_type", "category,question,answer,blood_donation")
                .OldAnnotation("Npgsql:Enum:phase", "draft,published")
                .OldAnnotation("Npgsql:Enum:user_type", "patient,doctor")
                .OldAnnotation("Npgsql:Enum:verification_status", "pending,more_info_needed,approved,rejected")
                .OldAnnotation("Npgsql:Enum:visibility", "public,private");
        }
    }
}
