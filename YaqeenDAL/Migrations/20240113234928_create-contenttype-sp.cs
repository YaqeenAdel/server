using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YaqeenDAL.Migrations
{
    /// <inheritdoc />
    public partial class createcontenttypesp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE OR REPLACE PROCEDURE insert_content(parent_content_id INTEGER, author_user_id text, raw jsonb, OUT rows_inserted INTEGER)
LANGUAGE plpgsql
AS $$
DECLARE
    generated_id INTEGER; rows_inserted INTEGER; 
BEGIN
INSERT INTO public.""ResourceLocalizations"" (""TranslationId"", ""Language"", ""Translation"") VALUES ((floor(random() * (100000000 - 1 + 1)) + 1), 'en', raw::jsonb) RETURNING ""TranslationId"" INTO generated_id; INSERT INTO public.""Contents"" ( ""ParentContentId"", ""AuthorUserId"", ""Raw"", ""Active"", ""CreatedDate"", ""Phase"", ""TranslationId"", ""Attachments"", ""Tags"" ) VALUES ( parent_content_id, author_user_id, raw::jsonb, TRUE, NOW(), 'published', generated_id, '[]'::jsonb, '[]'::jsonb ); GET DIAGNOSTICS rows_inserted = ROW_COUNT; 
END;
$$;
");
            migrationBuilder.Sql("CREATE OR REPLACE VIEW public.\"FlattenedResourceLocalizations\" AS SELECT t.\"TranslationId\", t.\"Language\", jsonb_each.key, (jsonb_each.value)::text AS value FROM (\"ResourceLocalizations\" t CROSS JOIN LATERAL jsonb_each(t.\"Translation\") jsonb_each(key, value));");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE insert_content;");
            migrationBuilder.Sql("DROP VIEW public.\"FlattenedResourceLocalizations\";");
        }
    }
}
