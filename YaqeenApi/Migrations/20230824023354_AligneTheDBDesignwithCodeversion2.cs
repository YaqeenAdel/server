using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YaqeenApi.Migrations
{
    /// <inheritdoc />
    public partial class AligneTheDBDesignwithCodeversion2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CancerStages_Patients_StageId",
                table: "CancerStages");

            migrationBuilder.AddForeignKey(
                name: "FK_CancerStages_Patients_StageId",
                table: "CancerStages",
                column: "StageId",
                principalTable: "Patients",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CancerStages_Patients_StageId",
                table: "CancerStages");

            migrationBuilder.AddForeignKey(
                name: "FK_CancerStages_Patients_StageId",
                table: "CancerStages",
                column: "StageId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
