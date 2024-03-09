using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YaqeenDAL.Migrations
{
    /// <inheritdoc />
    public partial class multiplesymptomsview : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("CREATE OR REPLACE VIEW public.\"SymptomSymptomLookups\" AS SELECT \"SymptomId\", UNNEST(\"SymptomLookupIds\") AS \"SymptomLookupId\" FROM public.\"Symptoms\";");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW public.\"SymptomSymptomLookups\";");
        }
    }
}
