using Microsoft.EntityFrameworkCore.Migrations;
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
            migrationBuilder.AddColumn<UserType>(
                name: "TargetUserType",
                table: "Interests",
                type: "user_type",
                nullable: false,
                defaultValue: UserType.Patient);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TargetUserType",
                table: "Interests");
        }
    }
}
