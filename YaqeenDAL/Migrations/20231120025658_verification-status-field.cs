using Microsoft.EntityFrameworkCore.Migrations;
using YaqeenDAL.Model;

#nullable disable

namespace YaqeenDAL.Migrations
{
    /// <inheritdoc />
    public partial class verificationstatusfield : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<VerificationStatus>(
                name: "Status",
                table: "VerificationStatusEvent",
                type: "verification_status",
                nullable: false,
                defaultValue: VerificationStatus.Pending);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "VerificationStatusEvent");
        }
    }
}
