﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace YaqeenDAL.Migrations
{
    /// <inheritdoc />
    public partial class questions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CertificationPath",
                table: "Doctors",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NationalIDPath",
                table: "Doctors",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Contents",
                columns: table => new
                {
                    ContentId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ParentContentId = table.Column<int>(type: "integer", nullable: true),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", rowVersion: true, nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", rowVersion: true, nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", rowVersion: true, nullable: true),
                    Raw = table.Column<Dictionary<string, string>>(type: "jsonb", nullable: false),
                    AuthorUserId = table.Column<string>(type: "text", nullable: false),
                    AssignedTo = table.Column<int>(type: "integer", nullable: true),
                    Phase = table.Column<int>(type: "integer", nullable: false),
                    Tags = table.Column<string[]>(type: "text[]", nullable: false),
                    Visibility = table.Column<int>(type: "integer", nullable: false),
                    Attachments = table.Column<string[]>(type: "text[]", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contents", x => x.ContentId);
                    table.ForeignKey(
                        name: "FK_Contents_Contents_ParentContentId",
                        column: x => x.ParentContentId,
                        principalTable: "Contents",
                        principalColumn: "ContentId");
                    table.ForeignKey(
                        name: "FK_Contents_Users_AuthorUserId",
                        column: x => x.AuthorUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contents_AssignedTo",
                table: "Contents",
                column: "AssignedTo");

            migrationBuilder.CreateIndex(
                name: "IX_Contents_AuthorUserId",
                table: "Contents",
                column: "AuthorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Contents_ParentContentId",
                table: "Contents",
                column: "ParentContentId");

            migrationBuilder.CreateIndex(
                name: "IX_Contents_Tags",
                table: "Contents",
                column: "Tags");

            migrationBuilder.CreateIndex(
                name: "IX_Contents_Type",
                table: "Contents",
                column: "Type");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contents");

            migrationBuilder.DropColumn(
                name: "CertificationPath",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "NationalIDPath",
                table: "Doctors");
        }
    }
}
