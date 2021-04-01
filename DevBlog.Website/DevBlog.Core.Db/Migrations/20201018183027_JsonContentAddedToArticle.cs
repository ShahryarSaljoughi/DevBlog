using Microsoft.EntityFrameworkCore.Migrations;

namespace DevBlog.Core.Db.Migrations
{
    public partial class JsonContentAddedToArticle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "content",
                table: "article");

            migrationBuilder.AddColumn<string>(
                name: "content_html",
                table: "article",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "content_json",
                table: "article",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "content_text",
                table: "article",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "content_html",
                table: "article");

            migrationBuilder.DropColumn(
                name: "content_json",
                table: "article");

            migrationBuilder.DropColumn(
                name: "content_text",
                table: "article");

            migrationBuilder.AddColumn<string>(
                name: "content",
                table: "article",
                type: "text",
                nullable: true);
        }
    }
}
