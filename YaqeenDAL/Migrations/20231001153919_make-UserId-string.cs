using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace YaqeenDAL.Migrations
{
    /// <inheritdoc />
    public partial class makeUserIdstring : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Doctors_DoctorId",
                table: "Answers");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookmarks_Doctors_UserId",
                table: "Bookmarks");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookmarks_Patients_UserId",
                table: "Bookmarks");

            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Users_UserId",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Users_VerificationStatus_VerifierUserId",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Interests_Patients_PatientUserId",
                table: "Interests");

            migrationBuilder.DropForeignKey(
                name: "FK_InterestUser_Interests_UserId",
                table: "InterestUser");

            migrationBuilder.DropForeignKey(
                name: "FK_InterestUser_Users_UsersUserId",
                table: "InterestUser");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Users_UserId",
                table: "Patients");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Patients_PatientUserId",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Users_UserId",
                table: "Questions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Questions_PatientUserId",
                table: "Questions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Patients",
                table: "Patients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InterestUser",
                table: "InterestUser");

            migrationBuilder.DropIndex(
                name: "IX_InterestUser_UsersUserId",
                table: "InterestUser");

            migrationBuilder.DropIndex(
                name: "IX_Interests_PatientUserId",
                table: "Interests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Doctors",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "PatientUserId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "InterestUser");

            migrationBuilder.DropColumn(
                name: "PatientUserId",
                table: "Interests");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "VerificationStatus_RowVersion",
                table: "Doctors");

            migrationBuilder.RenameColumn(
                name: "UsersUserId",
                table: "InterestUser",
                newName: "InterestsInterestId");

            migrationBuilder.RenameColumn(
                name: "VerificationStatus_VerifierUserId",
                table: "Doctors",
                newName: "VerificationStatusId");

            migrationBuilder.RenameColumn(
                name: "VerificationStatus_Notes",
                table: "Doctors",
                newName: "UserIdStr");

            migrationBuilder.RenameIndex(
                name: "IX_Doctors_VerificationStatus_VerifierUserId",
                table: "Doctors",
                newName: "IX_Doctors_VerificationStatusId");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Users",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<string>(
                name: "UserIdStr",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Questions",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<string>(
                name: "PatientUserIdStr",
                table: "Questions",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserIdStr",
                table: "Patients",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UsersUserIdStr",
                table: "InterestUser",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PatientUserIdStr",
                table: "Interests",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Bookmarks",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "DoctorId",
                table: "Answers",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "UserIdStr");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Patients",
                table: "Patients",
                column: "UserIdStr");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InterestUser",
                table: "InterestUser",
                columns: new[] { "InterestsInterestId", "UsersUserIdStr" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Doctors",
                table: "Doctors",
                column: "UserIdStr");

            migrationBuilder.CreateTable(
                name: "VerificationStatus",
                columns: table => new
                {
                    VerificationId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TargetDoctorUserId = table.Column<string>(type: "text", nullable: false),
                    VerifierUserId = table.Column<string>(type: "text", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VerificationStatus", x => x.VerificationId);
                    table.ForeignKey(
                        name: "FK_VerificationStatus_Doctors_TargetDoctorUserId",
                        column: x => x.TargetDoctorUserId,
                        principalTable: "Doctors",
                        principalColumn: "UserIdStr",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VerificationStatus_Users_VerifierUserId",
                        column: x => x.VerifierUserId,
                        principalTable: "Users",
                        principalColumn: "UserIdStr",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Questions_PatientUserIdStr",
                table: "Questions",
                column: "PatientUserIdStr");

            migrationBuilder.CreateIndex(
                name: "IX_InterestUser_UsersUserIdStr",
                table: "InterestUser",
                column: "UsersUserIdStr");

            migrationBuilder.CreateIndex(
                name: "IX_Interests_PatientUserIdStr",
                table: "Interests",
                column: "PatientUserIdStr");

            migrationBuilder.CreateIndex(
                name: "IX_VerificationStatus_TargetDoctorUserId",
                table: "VerificationStatus",
                column: "TargetDoctorUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VerificationStatus_VerifierUserId",
                table: "VerificationStatus",
                column: "VerifierUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Doctors_DoctorId",
                table: "Answers",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "UserIdStr",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookmarks_Doctors_UserId",
                table: "Bookmarks",
                column: "UserId",
                principalTable: "Doctors",
                principalColumn: "UserIdStr",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookmarks_Patients_UserId",
                table: "Bookmarks",
                column: "UserId",
                principalTable: "Patients",
                principalColumn: "UserIdStr",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Users_UserIdStr",
                table: "Doctors",
                column: "UserIdStr",
                principalTable: "Users",
                principalColumn: "UserIdStr",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_VerificationStatus_VerificationStatusId",
                table: "Doctors",
                column: "VerificationStatusId",
                principalTable: "VerificationStatus",
                principalColumn: "VerificationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Interests_Patients_PatientUserIdStr",
                table: "Interests",
                column: "PatientUserIdStr",
                principalTable: "Patients",
                principalColumn: "UserIdStr");

            migrationBuilder.AddForeignKey(
                name: "FK_InterestUser_Interests_InterestsInterestId",
                table: "InterestUser",
                column: "InterestsInterestId",
                principalTable: "Interests",
                principalColumn: "InterestId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InterestUser_Users_UsersUserIdStr",
                table: "InterestUser",
                column: "UsersUserIdStr",
                principalTable: "Users",
                principalColumn: "UserIdStr",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Users_UserIdStr",
                table: "Patients",
                column: "UserIdStr",
                principalTable: "Users",
                principalColumn: "UserIdStr",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Patients_PatientUserIdStr",
                table: "Questions",
                column: "PatientUserIdStr",
                principalTable: "Patients",
                principalColumn: "UserIdStr");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Users_UserId",
                table: "Questions",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserIdStr",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Doctors_DoctorId",
                table: "Answers");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookmarks_Doctors_UserId",
                table: "Bookmarks");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookmarks_Patients_UserId",
                table: "Bookmarks");

            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Users_UserIdStr",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_VerificationStatus_VerificationStatusId",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Interests_Patients_PatientUserIdStr",
                table: "Interests");

            migrationBuilder.DropForeignKey(
                name: "FK_InterestUser_Interests_InterestsInterestId",
                table: "InterestUser");

            migrationBuilder.DropForeignKey(
                name: "FK_InterestUser_Users_UsersUserIdStr",
                table: "InterestUser");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Users_UserIdStr",
                table: "Patients");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Patients_PatientUserIdStr",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Users_UserId",
                table: "Questions");

            migrationBuilder.DropTable(
                name: "VerificationStatus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Questions_PatientUserIdStr",
                table: "Questions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Patients",
                table: "Patients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InterestUser",
                table: "InterestUser");

            migrationBuilder.DropIndex(
                name: "IX_InterestUser_UsersUserIdStr",
                table: "InterestUser");

            migrationBuilder.DropIndex(
                name: "IX_Interests_PatientUserIdStr",
                table: "Interests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Doctors",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "UserIdStr",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PatientUserIdStr",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "UserIdStr",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "UsersUserIdStr",
                table: "InterestUser");

            migrationBuilder.DropColumn(
                name: "PatientUserIdStr",
                table: "Interests");

            migrationBuilder.RenameColumn(
                name: "InterestsInterestId",
                table: "InterestUser",
                newName: "UsersUserId");

            migrationBuilder.RenameColumn(
                name: "VerificationStatusId",
                table: "Doctors",
                newName: "VerificationStatus_VerifierUserId");

            migrationBuilder.RenameColumn(
                name: "UserIdStr",
                table: "Doctors",
                newName: "VerificationStatus_Notes");

            migrationBuilder.RenameIndex(
                name: "IX_Doctors_VerificationStatusId",
                table: "Doctors",
                newName: "IX_Doctors_VerificationStatus_VerifierUserId");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Users",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Questions",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<int>(
                name: "PatientUserId",
                table: "Questions",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Patients",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "InterestUser",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PatientUserId",
                table: "Interests",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Doctors",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<byte[]>(
                name: "VerificationStatus_RowVersion",
                table: "Doctors",
                type: "bytea",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Bookmarks",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "DoctorId",
                table: "Answers",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Patients",
                table: "Patients",
                column: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InterestUser",
                table: "InterestUser",
                columns: new[] { "UserId", "UsersUserId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Doctors",
                table: "Doctors",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_PatientUserId",
                table: "Questions",
                column: "PatientUserId");

            migrationBuilder.CreateIndex(
                name: "IX_InterestUser_UsersUserId",
                table: "InterestUser",
                column: "UsersUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Interests_PatientUserId",
                table: "Interests",
                column: "PatientUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Doctors_DoctorId",
                table: "Answers",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_Doctors_Users_UserId",
                table: "Doctors",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Users_VerificationStatus_VerifierUserId",
                table: "Doctors",
                column: "VerificationStatus_VerifierUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Interests_Patients_PatientUserId",
                table: "Interests",
                column: "PatientUserId",
                principalTable: "Patients",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_InterestUser_Interests_UserId",
                table: "InterestUser",
                column: "UserId",
                principalTable: "Interests",
                principalColumn: "InterestId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InterestUser_Users_UsersUserId",
                table: "InterestUser",
                column: "UsersUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Users_UserId",
                table: "Patients",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Patients_PatientUserId",
                table: "Questions",
                column: "PatientUserId",
                principalTable: "Patients",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Users_UserId",
                table: "Questions",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
