using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace YaqeenDAL.Migrations
{
    /// <inheritdoc />
    public partial class reminders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Medications");

            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:content_type", "category,question,answer,blood_donation")
                .Annotation("Npgsql:Enum:day_of_the_week", "sunday,monday,tuesday,wednesday,thursday,friday,saturday")
                .Annotation("Npgsql:Enum:frequency_interval", "every_day,every8hours,every12hours,every_other_day")
                .Annotation("Npgsql:Enum:medication_type", "tablet,liquid_filled_capsule,capsule,cream,device,drops,foam,gel,inhaler,injection,liquid,lotion,ointment,patch,powder,spray,suppository,topical")
                .Annotation("Npgsql:Enum:medication_unit", "mg,mcg,g,ml,percentage")
                .Annotation("Npgsql:Enum:phase", "draft,published")
                .Annotation("Npgsql:Enum:schedule_entity_type", "medication,routine_test,appointment")
                .Annotation("Npgsql:Enum:schedule_frequency", "regular_intervals,specific_days,as_needed")
                .Annotation("Npgsql:Enum:user_type", "patient,doctor")
                .Annotation("Npgsql:Enum:verification_status", "pending,more_info_needed,approved,rejected")
                .Annotation("Npgsql:Enum:visibility", "public,private")
                .OldAnnotation("Npgsql:Enum:content_type", "category,question,answer,blood_donation")
                .OldAnnotation("Npgsql:Enum:phase", "draft,published")
                .OldAnnotation("Npgsql:Enum:user_type", "patient,doctor")
                .OldAnnotation("Npgsql:Enum:verification_status", "pending,more_info_needed,approved,rejected")
                .OldAnnotation("Npgsql:Enum:visibility", "public,private");

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    ScheduleId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CronExpression = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    EntityType = table.Column<int>(type: "integer", nullable: false),
                    Entity = table.Column<Dictionary<string, string>>(type: "jsonb", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.ScheduleId);
                    table.ForeignKey(
                        name: "FK_Schedules_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SymptomLookups",
                columns: table => new
                {
                    SymptomLookupId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SymptomLookups", x => x.SymptomLookupId);
                });

            migrationBuilder.CreateTable(
                name: "ScheduleInstances",
                columns: table => new
                {
                    ScheduleInstanceId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ScheduleId = table.Column<int>(type: "integer", nullable: false),
                    Time = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Done = table.Column<bool>(type: "boolean", nullable: true),
                    Skipped = table.Column<bool>(type: "boolean", nullable: true),
                    Missed = table.Column<bool>(type: "boolean", nullable: true),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleInstances", x => x.ScheduleInstanceId);
                    table.ForeignKey(
                        name: "FK_ScheduleInstances_Schedules_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "Schedules",
                        principalColumn: "ScheduleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Symptoms",
                columns: table => new
                {
                    SymptomId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SymptomLookupId = table.Column<int>(type: "integer", nullable: false),
                    PatientUserId = table.Column<string>(type: "text", nullable: false),
                    Time = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Details = table.Column<string>(type: "text", nullable: false),
                    PhotoLink = table.Column<string>(type: "text", nullable: true),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Symptoms", x => x.SymptomId);
                    table.ForeignKey(
                        name: "FK_Symptoms_Patients_PatientUserId",
                        column: x => x.PatientUserId,
                        principalTable: "Patients",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Symptoms_SymptomLookups_SymptomLookupId",
                        column: x => x.SymptomLookupId,
                        principalTable: "SymptomLookups",
                        principalColumn: "SymptomLookupId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScheduleSymptom",
                columns: table => new
                {
                    SchedulesScheduleId = table.Column<int>(type: "integer", nullable: false),
                    SymptomId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleSymptom", x => new { x.SchedulesScheduleId, x.SymptomId });
                    table.ForeignKey(
                        name: "FK_ScheduleSymptom_Schedules_SchedulesScheduleId",
                        column: x => x.SchedulesScheduleId,
                        principalTable: "Schedules",
                        principalColumn: "ScheduleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScheduleSymptom_Symptoms_SymptomId",
                        column: x => x.SymptomId,
                        principalTable: "Symptoms",
                        principalColumn: "SymptomId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleInstances_ScheduleId",
                table: "ScheduleInstances",
                column: "ScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_EntityType_UserId",
                table: "Schedules",
                columns: new[] { "EntityType", "UserId" });

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_UserId",
                table: "Schedules",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleSymptom_SymptomId",
                table: "ScheduleSymptom",
                column: "SymptomId");

            migrationBuilder.CreateIndex(
                name: "IX_Symptoms_PatientUserId",
                table: "Symptoms",
                column: "PatientUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Symptoms_SymptomLookupId",
                table: "Symptoms",
                column: "SymptomLookupId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ScheduleInstances");

            migrationBuilder.DropTable(
                name: "ScheduleSymptom");

            migrationBuilder.DropTable(
                name: "Schedules");

            migrationBuilder.DropTable(
                name: "Symptoms");

            migrationBuilder.DropTable(
                name: "SymptomLookups");

            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:content_type", "category,question,answer,blood_donation")
                .Annotation("Npgsql:Enum:phase", "draft,published")
                .Annotation("Npgsql:Enum:user_type", "patient,doctor")
                .Annotation("Npgsql:Enum:verification_status", "pending,more_info_needed,approved,rejected")
                .Annotation("Npgsql:Enum:visibility", "public,private")
                .OldAnnotation("Npgsql:Enum:content_type", "category,question,answer,blood_donation")
                .OldAnnotation("Npgsql:Enum:day_of_the_week", "sunday,monday,tuesday,wednesday,thursday,friday,saturday")
                .OldAnnotation("Npgsql:Enum:frequency_interval", "every_day,every8hours,every12hours,every_other_day")
                .OldAnnotation("Npgsql:Enum:medication_type", "tablet,liquid_filled_capsule,capsule,cream,device,drops,foam,gel,inhaler,injection,liquid,lotion,ointment,patch,powder,spray,suppository,topical")
                .OldAnnotation("Npgsql:Enum:medication_unit", "mg,mcg,g,ml,percentage")
                .OldAnnotation("Npgsql:Enum:phase", "draft,published")
                .OldAnnotation("Npgsql:Enum:schedule_entity_type", "medication,routine_test,appointment")
                .OldAnnotation("Npgsql:Enum:schedule_frequency", "regular_intervals,specific_days,as_needed")
                .OldAnnotation("Npgsql:Enum:user_type", "patient,doctor")
                .OldAnnotation("Npgsql:Enum:verification_status", "pending,more_info_needed,approved,rejected")
                .OldAnnotation("Npgsql:Enum:visibility", "public,private");

            migrationBuilder.CreateTable(
                name: "Medications",
                columns: table => new
                {
                    MedicationId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PatientId = table.Column<string>(type: "text", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Dosage = table.Column<int>(type: "integer", nullable: false),
                    Duration = table.Column<int>(type: "integer", nullable: false),
                    EndDate = table.Column<string>(type: "text", nullable: false),
                    Frequency = table.Column<string>(type: "text", nullable: false),
                    MedicationName = table.Column<string>(type: "text", nullable: false),
                    MedicationType = table.Column<string>(type: "text", nullable: false),
                    Photo = table.Column<string>(type: "text", nullable: true),
                    StartDate = table.Column<string>(type: "text", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medications", x => x.MedicationId);
                    table.ForeignKey(
                        name: "FK_Medications_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Medications_PatientId",
                table: "Medications",
                column: "PatientId");
        }
    }
}
