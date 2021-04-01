using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DevBlog.Core.Db.Migrations
{
    public partial class addTag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "article",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "seen_count",
                table: "article",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "tag_id",
                table: "article",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "tag",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tag", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "article_tag",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    article_id = table.Column<Guid>(nullable: false),
                    tag_id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_article_tag", x => x.id);
                    table.ForeignKey(
                        name: "fk_article_tag_article_article_id",
                        column: x => x.article_id,
                        principalTable: "article",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_article_tag_tag_tag_id",
                        column: x => x.tag_id,
                        principalTable: "tag",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_article_tag_id",
                table: "article",
                column: "tag_id");

            migrationBuilder.CreateIndex(
                name: "ix_article_tag_article_id",
                table: "article_tag",
                column: "article_id");

            migrationBuilder.CreateIndex(
                name: "ix_article_tag_tag_id",
                table: "article_tag",
                column: "tag_id");

            migrationBuilder.AddForeignKey(
                name: "fk_article_tag_tag_id",
                table: "article",
                column: "tag_id",
                principalTable: "tag",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_article_tag_tag_id",
                table: "article");

            migrationBuilder.DropTable(
                name: "article_tag");

            migrationBuilder.DropTable(
                name: "tag");

            migrationBuilder.DropIndex(
                name: "ix_article_tag_id",
                table: "article");

            migrationBuilder.DropColumn(
                name: "description",
                table: "article");

            migrationBuilder.DropColumn(
                name: "seen_count",
                table: "article");

            migrationBuilder.DropColumn(
                name: "tag_id",
                table: "article");
        }
    }
}
