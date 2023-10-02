using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YaqeenDAL.Migrations
{
    /// <inheritdoc />
    public partial class rminterestspatients : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Interests_Patients_PatientUserId",
                table: "Interests");

            migrationBuilder.DropIndex(
                name: "IX_Interests_PatientUserId",
                table: "Interests");

            migrationBuilder.DropColumn(
                name: "PatientUserId",
                table: "Interests");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PatientUserId",
                table: "Interests",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Interests_PatientUserId",
                table: "Interests",
                column: "PatientUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Interests_Patients_PatientUserId",
                table: "Interests",
                column: "PatientUserId",
                principalTable: "Patients",
                principalColumn: "UserId");
        }
    }
}
