﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YaqeenDAL.Migrations
{
    /// <inheritdoc />
    public partial class cronupdateregex : Migration
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
                sql: "\"CronExpression\" ~* '^(\\*|[0-9]{1,2})(\\/[0-9]{1,2})?\\s+(\\*|[0-9]{1,2})(\\/[0-9]{1,2})?\\s+(\\*|[0-9]{1,2})(\\/[0-9]{1,2})?\\s+(\\*|[0-9]{1,2})(\\/[0-9]{1,2})?\\s+(\\*|[0-9]{1,2})(\\/[0-9]{1,2})?$'");
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
                sql: "\"CronExpression\" ~* '/(@(annually|yearly|monthly|weekly|daily|hourly|reboot))|(@every (\\d+(ns|us|µs|ms|s|m|h))+)|((((\\d+,)+\\d+|(\\d+(\\/|-)\\d+)|\\d+|\\*) ?){5})/'");
        }
    }
}
