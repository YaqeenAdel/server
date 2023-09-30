using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace YaqeenApi.Migrations
{
    /// <inheritdoc />
    public partial class AligneTheDBDesignwithCode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CancerStage",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "CancerType",
                table: "Patients");

            migrationBuilder.AddColumn<bool>(
                name: "AgreedTerms",
                table: "Users",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IdpUserIdentifier",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Users",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Users",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsEmailVerified",
                table: "Users",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsVerified",
                table: "Doctors",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "AreaofInterests",
                columns: table => new
                {
                    AreaId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AreaName = table.Column<string>(type: "text", nullable: false),
                    Logo = table.Column<string>(type: "text", nullable: false),
                    PatientId = table.Column<int>(type: "integer", nullable: false),
                    DoctorId = table.Column<int>(type: "integer", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreaofInterests", x => x.AreaId);
                    table.ForeignKey(
                        name: "FK_AreaofInterests_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AreaofInterests_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CancerStages",
                columns: table => new
                {
                    StageId = table.Column<int>(type: "integer", nullable: false),
                    StageName = table.Column<string>(type: "text", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CancerStages", x => x.StageId);
                    table.ForeignKey(
                        name: "FK_CancerStages_Patients_StageId",
                        column: x => x.StageId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CancerTypes",
                columns: table => new
                {
                    CancerId = table.Column<int>(type: "integer", nullable: false),
                    CancerTypeName = table.Column<string>(type: "text", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CancerTypes", x => x.CancerId);
                    table.ForeignKey(
                        name: "FK_CancerTypes_Patients_CancerId",
                        column: x => x.CancerId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DoctorAreaofInterests",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    AreaId = table.Column<int>(type: "integer", nullable: false),
                    DoctorId = table.Column<int>(type: "integer", nullable: false),
                    AreaofInterestAreaId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorAreaofInterests", x => new { x.UserId, x.AreaId });
                    table.ForeignKey(
                        name: "FK_DoctorAreaofInterests_AreaofInterests_AreaofInterestAreaId",
                        column: x => x.AreaofInterestAreaId,
                        principalTable: "AreaofInterests",
                        principalColumn: "AreaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DoctorAreaofInterests_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PatientAreaofInterests",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    AreaId = table.Column<int>(type: "integer", nullable: false),
                    PatientId = table.Column<int>(type: "integer", nullable: false),
                    AreaofInterestAreaId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientAreaofInterests", x => new { x.UserId, x.AreaId });
                    table.ForeignKey(
                        name: "FK_PatientAreaofInterests_AreaofInterests_AreaofInterestAreaId",
                        column: x => x.AreaofInterestAreaId,
                        principalTable: "AreaofInterests",
                        principalColumn: "AreaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientAreaofInterests_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AreaofInterests_DoctorId",
                table: "AreaofInterests",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_AreaofInterests_PatientId",
                table: "AreaofInterests",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorAreaofInterests_AreaofInterestAreaId",
                table: "DoctorAreaofInterests",
                column: "AreaofInterestAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorAreaofInterests_DoctorId",
                table: "DoctorAreaofInterests",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientAreaofInterests_AreaofInterestAreaId",
                table: "PatientAreaofInterests",
                column: "AreaofInterestAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientAreaofInterests_PatientId",
                table: "PatientAreaofInterests",
                column: "PatientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CancerStages");

            migrationBuilder.DropTable(
                name: "CancerTypes");

            migrationBuilder.DropTable(
                name: "DoctorAreaofInterests");

            migrationBuilder.DropTable(
                name: "PatientAreaofInterests");

            migrationBuilder.DropTable(
                name: "AreaofInterests");

            migrationBuilder.DropColumn(
                name: "AgreedTerms",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IdpUserIdentifier",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsEmailVerified",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsVerified",
                table: "Doctors");

            migrationBuilder.AddColumn<string>(
                name: "CancerStage",
                table: "Patients",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CancerType",
                table: "Patients",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
