using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using YaqeenDAL.Model;

#nullable disable

namespace YaqeenDAL.Migrations
{
    /// <inheritdoc />
    public partial class contentsupdates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Dictionary<string, string>>(
                name: "Tags",
                table: "Contents",
                type: "jsonb",
                nullable: false,
                oldClrType: typeof(string[]),
                oldType: "text[]");

            migrationBuilder.AlterColumn<Attachment>(
                name: "Attachments",
                table: "Contents",
                type: "jsonb",
                nullable: false,
                oldClrType: typeof(string[]),
                oldType: "text[]");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string[]>(
                name: "Tags",
                table: "Contents",
                type: "text[]",
                nullable: false,
                oldClrType: typeof(Dictionary<string, string>),
                oldType: "jsonb");

            migrationBuilder.AlterColumn<string[]>(
                name: "Attachments",
                table: "Contents",
                type: "text[]",
                nullable: false,
                oldClrType: typeof(Attachment),
                oldType: "jsonb");
        }
    }
}
