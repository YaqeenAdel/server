using Microsoft.EntityFrameworkCore.Migrations;
using YaqeenDAL.Model;

#nullable disable

namespace YaqeenDAL.Migrations
{
    /// <inheritdoc />
    public partial class fixenumtypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<ScheduleEntityType>(
                name: "EntityType",
                table: "Schedules",
                type: "schedule_entity_type",
                nullable: false,
                defaultValue: ScheduleEntityType.Medication);

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_EntityType_UserId",
                table: "Schedules",
                columns: new[] { "EntityType", "UserId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Schedules_EntityType_UserId",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "EntityType",
                table: "Schedules");
        }
    }
}
