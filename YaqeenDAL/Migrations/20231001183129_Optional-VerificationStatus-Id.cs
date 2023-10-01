using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YaqeenDAL.Migrations
{
    /// <inheritdoc />
    public partial class OptionalVerificationStatusId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_VerificationStatus_VerificationStatusId",
                table: "Doctors");

            migrationBuilder.AlterColumn<int>(
                name: "VerificationStatusId",
                table: "Doctors",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_VerificationStatus_VerificationStatusId",
                table: "Doctors",
                column: "VerificationStatusId",
                principalTable: "VerificationStatus",
                principalColumn: "VerificationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_VerificationStatus_VerificationStatusId",
                table: "Doctors");

            migrationBuilder.AlterColumn<int>(
                name: "VerificationStatusId",
                table: "Doctors",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_VerificationStatus_VerificationStatusId",
                table: "Doctors",
                column: "VerificationStatusId",
                principalTable: "VerificationStatus",
                principalColumn: "VerificationId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
