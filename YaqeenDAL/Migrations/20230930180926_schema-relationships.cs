using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace YaqeenDAL.Migrations
{
    /// <inheritdoc />
    public partial class schemarelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    ArticleId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    Category = table.Column<string>(type: "text", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.ArticleId);
                });

            migrationBuilder.CreateTable(
                name: "CancerStages",
                columns: table => new
                {
                    StageId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StageName = table.Column<string>(type: "text", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CancerStages", x => x.StageId);
                });

            migrationBuilder.CreateTable(
                name: "CancerTypes",
                columns: table => new
                {
                    CancerId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CancerTypeName = table.Column<string>(type: "text", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CancerTypes", x => x.CancerId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    MobileNumber = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: false),
                    AgreedTerms = table.Column<bool>(type: "boolean", nullable: false),
                    Gender = table.Column<string>(type: "text", nullable: true),
                    IsEmailVerified = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedAt = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    University = table.Column<string>(type: "text", nullable: false),
                    Degree = table.Column<string>(type: "text", nullable: false),
                    MedicalField = table.Column<string>(type: "text", nullable: false),
                    VerificationStatus_VerifierUserId = table.Column<int>(type: "integer", nullable: false),
                    VerificationStatus_RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: false),
                    VerificationStatus_Notes = table.Column<string>(type: "text", nullable: false),
                    AnswerId = table.Column<string>(type: "text", nullable: false),
                    BookmarkId = table.Column<string>(type: "text", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Doctors_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Doctors_Users_VerificationStatus_VerifierUserId",
                        column: x => x.VerificationStatus_VerifierUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    AgeGroup = table.Column<int>(type: "integer", nullable: false),
                    CancerTypeId = table.Column<int>(type: "integer", nullable: false),
                    CancerStageId = table.Column<int>(type: "integer", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Patients_CancerStages_CancerStageId",
                        column: x => x.CancerStageId,
                        principalTable: "CancerStages",
                        principalColumn: "StageId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Patients_CancerTypes_CancerTypeId",
                        column: x => x.CancerTypeId,
                        principalTable: "CancerTypes",
                        principalColumn: "CancerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Patients_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bookmarks",
                columns: table => new
                {
                    BookmarkId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    ArticleId = table.Column<int>(type: "integer", nullable: true),
                    Type = table.Column<string>(type: "text", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookmarks", x => x.BookmarkId);
                    table.ForeignKey(
                        name: "FK_Bookmarks_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "ArticleId");
                    table.ForeignKey(
                        name: "FK_Bookmarks_Doctors_BookmarkId",
                        column: x => x.BookmarkId,
                        principalTable: "Doctors",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookmarks_Doctors_UserId",
                        column: x => x.UserId,
                        principalTable: "Doctors",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookmarks_Patients_UserId",
                        column: x => x.UserId,
                        principalTable: "Patients",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Interests",
                columns: table => new
                {
                    InterestId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    LogoURL = table.Column<string>(type: "text", nullable: false),
                    PatientUserId = table.Column<int>(type: "integer", nullable: true),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interests", x => x.InterestId);
                    table.ForeignKey(
                        name: "FK_Interests_Patients_PatientUserId",
                        column: x => x.PatientUserId,
                        principalTable: "Patients",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    QuestionId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Category = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    PatientUserId = table.Column<int>(type: "integer", nullable: true),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.QuestionId);
                    table.ForeignKey(
                        name: "FK_Questions_Patients_PatientUserId",
                        column: x => x.PatientUserId,
                        principalTable: "Patients",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_Questions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InterestUser",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    UsersUserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterestUser", x => new { x.UserId, x.UsersUserId });
                    table.ForeignKey(
                        name: "FK_InterestUser_Interests_UserId",
                        column: x => x.UserId,
                        principalTable: "Interests",
                        principalColumn: "InterestId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InterestUser_Users_UsersUserId",
                        column: x => x.UsersUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    AnswerId = table.Column<int>(type: "integer", nullable: false),
                    DoctorId = table.Column<int>(type: "integer", nullable: false),
                    QuestionId = table.Column<int>(type: "integer", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.AnswerId);
                    table.ForeignKey(
                        name: "FK_Answers_Doctors_AnswerId",
                        column: x => x.AnswerId,
                        principalTable: "Doctors",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Answers_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Answers_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "QuestionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answers_DoctorId",
                table: "Answers",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Answers_QuestionId",
                table: "Answers",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookmarks_ArticleId",
                table: "Bookmarks",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookmarks_UserId",
                table: "Bookmarks",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_VerificationStatus_VerifierUserId",
                table: "Doctors",
                column: "VerificationStatus_VerifierUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Interests_PatientUserId",
                table: "Interests",
                column: "PatientUserId");

            migrationBuilder.CreateIndex(
                name: "IX_InterestUser_UsersUserId",
                table: "InterestUser",
                column: "UsersUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_CancerStageId",
                table: "Patients",
                column: "CancerStageId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_CancerTypeId",
                table: "Patients",
                column: "CancerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_PatientUserId",
                table: "Questions",
                column: "PatientUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_UserId",
                table: "Questions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_MobileNumber",
                table: "Users",
                column: "MobileNumber",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "Bookmarks");

            migrationBuilder.DropTable(
                name: "InterestUser");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Interests");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "CancerStages");

            migrationBuilder.DropTable(
                name: "CancerTypes");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
