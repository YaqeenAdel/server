using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using YaqeenDAL.Model;

#nullable disable

namespace YaqeenDAL.Migrations
{
    /// <inheritdoc />
    public partial class verificationstatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_VerificationStatus_VerificationStatusId",
                table: "Doctors");

            migrationBuilder.DropTable(
                name: "VerificationStatus");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_VerificationStatusId",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "VerificationStatusId",
                table: "Doctors");

            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:verification_status", "pending,approved,rejected,more_info_needed");

            migrationBuilder.AddColumn<VerificationStatus>(
                name: "VerificationStatus",
                table: "Doctors",
                type: "verification_status",
                nullable: false,
                defaultValue: VerificationStatus.Pending);

            migrationBuilder.CreateTable(
                name: "VerificationStatusEvent",
                columns: table => new
                {
                    TargetDoctorUserId = table.Column<string>(type: "text", nullable: false),
                    VerifierUserId = table.Column<string>(type: "text", nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: true),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VerificationStatusEvent", x => x.TargetDoctorUserId);
                    table.ForeignKey(
                        name: "FK_VerificationStatusEvent_Doctors_TargetDoctorUserId",
                        column: x => x.TargetDoctorUserId,
                        principalTable: "Doctors",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VerificationStatusEvent_Doctors_UserId",
                        column: x => x.UserId,
                        principalTable: "Doctors",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_VerificationStatusEvent_Users_VerifierUserId",
                        column: x => x.VerifierUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VerificationStatusEvent_UserId",
                table: "VerificationStatusEvent",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_VerificationStatusEvent_VerifierUserId",
                table: "VerificationStatusEvent",
                column: "VerifierUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VerificationStatusEvent");

            migrationBuilder.DropColumn(
                name: "VerificationStatus",
                table: "Doctors");

            migrationBuilder.AlterDatabase()
                .OldAnnotation("Npgsql:Enum:verification_status", "pending,approved,rejected,more_info_needed");

            migrationBuilder.AddColumn<int>(
                name: "VerificationStatusId",
                table: "Doctors",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "VerificationStatus",
                columns: table => new
                {
                    VerificationId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TargetDoctorUserId = table.Column<string>(type: "text", nullable: false),
                    VerifierUserId = table.Column<string>(type: "text", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Notes = table.Column<string>(type: "text", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VerificationStatus", x => x.VerificationId);
                    table.ForeignKey(
                        name: "FK_VerificationStatus_Doctors_TargetDoctorUserId",
                        column: x => x.TargetDoctorUserId,
                        principalTable: "Doctors",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VerificationStatus_Users_VerifierUserId",
                        column: x => x.VerifierUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_VerificationStatusId",
                table: "Doctors",
                column: "VerificationStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_VerificationStatus_TargetDoctorUserId",
                table: "VerificationStatus",
                column: "TargetDoctorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_VerificationStatus_VerifierUserId",
                table: "VerificationStatus",
                column: "VerifierUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_VerificationStatus_VerificationStatusId",
                table: "Doctors",
                column: "VerificationStatusId",
                principalTable: "VerificationStatus",
                principalColumn: "VerificationId");
        }
    }
}
