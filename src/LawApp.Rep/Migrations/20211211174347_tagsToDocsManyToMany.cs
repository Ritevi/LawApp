using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LawApp.Rep.Migrations
{
    public partial class tagsToDocsManyToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Docs_DocId",
                table: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Tags_DocId",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "DocId",
                table: "Tags");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Questions",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "DocTag",
                columns: table => new
                {
                    DocsId = table.Column<Guid>(type: "uuid", nullable: false),
                    TagsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocTag", x => new { x.DocsId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_DocTag_Docs_DocsId",
                        column: x => x.DocsId,
                        principalTable: "Docs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DocTag_Tags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DocTag_TagsId",
                table: "DocTag",
                column: "TagsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DocTag");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Questions");

            migrationBuilder.AddColumn<Guid>(
                name: "DocId",
                table: "Tags",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tags_DocId",
                table: "Tags",
                column: "DocId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Docs_DocId",
                table: "Tags",
                column: "DocId",
                principalTable: "Docs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
