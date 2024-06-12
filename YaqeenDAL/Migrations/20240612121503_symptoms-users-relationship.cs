using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YaqeenDAL.Migrations
{
    /// <inheritdoc />
    public partial class symptomsusersrelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Symptoms_Patients_PatientUserId",
                table: "Symptoms");

            migrationBuilder.AddForeignKey(
                name: "FK_Symptoms_Users_PatientUserId",
                table: "Symptoms",
                column: "PatientUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Symptoms_Users_PatientUserId",
                table: "Symptoms");

            migrationBuilder.AddForeignKey(
                name: "FK_Symptoms_Patients_PatientUserId",
                table: "Symptoms",
                column: "PatientUserId",
                principalTable: "Patients",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
