using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YaqeenDAL.Migrations
{
    /// <inheritdoc />
    public partial class cronfixregex2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CronExpression",
                table: "Schedules");

            migrationBuilder.AddCheckConstraint(
                name: "CronExpression",
                table: "Schedules",
                sql: "\"CronExpression\" ~* '^((\\*|[0-5]?[0-9])(\\/[0-5]?[0-9])?\\s*){4}((\\*|[0-5]?[0-9])|,)+$'");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CronExpression",
                table: "Schedules");

            migrationBuilder.AddCheckConstraint(
                name: "CronExpression",
                table: "Schedules",
                sql: "\"CronExpression\" ~* '^(\\*|[0-9]{1,2})(\\/[0-9]{1,2})?\\s+(\\*|[0-9]{1,2})(\\/[0-9]{1,2})?\\s+(\\*|[0-9]{1,2})(\\/[0-9]{1,2})?\\s+(\\*|[0-9]{1,2})(\\/[0-9]{1,2})?\\s+(\\*|[0-9]{1,2})(\\/[0-9]{1,2})?$'");
        }
    }
}
