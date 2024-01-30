using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YaqeenDAL.Migrations
{
    /// <inheritdoc />
    public partial class fixenumtypes1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Schedules_EntityType_UserId",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "EntityType",
                table: "Schedules");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EntityType",
                table: "Schedules",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_EntityType_UserId",
                table: "Schedules",
                columns: new[] { "EntityType", "UserId" });
        }
    }
}
