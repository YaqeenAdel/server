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
            migrationBuilder.Sql("CREATE OR REPLACE PROCEDURE insert_content(parent_content_id INTEGER, author_user_id text, raw jsonb, OUT rows_inserted INTEGER) DECLARE generated_id integer; rows_inserted INTEGER; INSERT INTO public.\"ResourceLocalizations\" (\"TranslationId\", \"Language\", \"Translation\") VALUES ((floor(random() * (100000000 - 1 + 1)) + 1), 'en', raw::jsonb) RETURNING \"TranslationId\" INTO generated_id; INSERT INTO public.\"Contents\" ( \"ParentContentId\", \"AuthorUserId\", \"Raw\", \"Active\", \"CreatedDate\", \"Phase\", \"TranslationId\", \"Attachments\", \"Tags\" ) VALUES ( parent_content_id, author_user_id, raw::jsonb, TRUE, NOW(), 'published', generated_id, '[]'::jsonb, '[]'::jsonb ); GET DIAGNOSTICS rows_inserted = ROW_COUNT; END;");
            migrationBuilder.Sql("CREATE OR REPLACE PROCEDURE insert_content(parent_content_id INTEGER, author_user_id text, raw jsonb, OUT rows_inserted INTEGER) LANGUAGE plpgsql; AS $$; DECLARE generated_id INTEGER; rows_inserted INTEGER; BEGIN INSERT INTO public.\"ResourceLocalizations\" (\"TranslationId\", \"Language\", \"Translation\") VALUES ((floor(random() * (100000000 - 1 + 1)) + 1), 'en', raw::jsonb) RETURNING \"TranslationId\" INTO generated_id; INSERT INTO public.\"Contents\" ( \"ParentContentId\", \"AuthorUserId\", \"Raw\", \"Active\", \"CreatedDate\", \"Phase\", \"TranslationId\", \"Attachments\", \"Tags\" ) VALUES ( parent_content_id, author_user_id, raw::jsonb, TRUE, NOW(), 'published', generated_id, '[]'::jsonb, '[]'::jsonb ); GET DIAGNOSTICS rows_inserted = ROW_COUNT; END;$$;");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE insert_content;");
            migrationBuilder.Sql("DROP VIEW public.\"FlattenedResourceLocalizations\";");
        }
    }
}
