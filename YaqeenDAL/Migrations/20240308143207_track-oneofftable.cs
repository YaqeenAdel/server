using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using YaqeenDAL.Model;

#nullable disable

namespace YaqeenDAL.Migrations
{
    /// <inheritdoc />
    public partial class trackoneofftable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OneOffScheduleScheduleId",
                table: "Symptoms",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "OneOffSchedules",
                columns: table => new
                {
                    ScheduleId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    EntityType = table.Column<ScheduleEntityType>(type: "schedule_entity_type", nullable: false),
                    Entity = table.Column<Dictionary<string, string>>(type: "jsonb", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OneOffSchedules", x => x.ScheduleId);
                    table.ForeignKey(
                        name: "FK_OneOffSchedules_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Symptoms_OneOffScheduleScheduleId",
                table: "Symptoms",
                column: "OneOffScheduleScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_OneOffSchedules_EntityType_UserId",
                table: "OneOffSchedules",
                columns: new[] { "EntityType", "UserId" });

            migrationBuilder.CreateIndex(
                name: "IX_OneOffSchedules_UserId",
                table: "OneOffSchedules",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Symptoms_OneOffSchedules_OneOffScheduleScheduleId",
                table: "Symptoms",
                column: "OneOffScheduleScheduleId",
                principalTable: "OneOffSchedules",
                principalColumn: "ScheduleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Symptoms_OneOffSchedules_OneOffScheduleScheduleId",
                table: "Symptoms");

            migrationBuilder.DropTable(
                name: "OneOffSchedules");

            migrationBuilder.DropIndex(
                name: "IX_Symptoms_OneOffScheduleScheduleId",
                table: "Symptoms");

            migrationBuilder.DropColumn(
                name: "OneOffScheduleScheduleId",
                table: "Symptoms");
        }
    }
}
