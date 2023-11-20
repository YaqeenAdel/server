using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YaqeenDAL.Migrations
{
    /// <inheritdoc />
    public partial class reorderverificationstatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:user_type", "patient,doctor")
                .Annotation("Npgsql:Enum:verification_status", "pending,more_info_needed,approved,rejected")
                .OldAnnotation("Npgsql:Enum:user_type", "patient,doctor")
                .OldAnnotation("Npgsql:Enum:verification_status", "pending,approved,more_info_needed,rejected");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:user_type", "patient,doctor")
                .Annotation("Npgsql:Enum:verification_status", "pending,approved,more_info_needed,rejected")
                .OldAnnotation("Npgsql:Enum:user_type", "patient,doctor")
                .OldAnnotation("Npgsql:Enum:verification_status", "pending,more_info_needed,approved,rejected");
        }
    }
}
