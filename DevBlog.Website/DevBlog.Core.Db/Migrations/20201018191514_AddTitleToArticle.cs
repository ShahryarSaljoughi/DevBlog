using Microsoft.EntityFrameworkCore.Migrations;

namespace DevBlog.Core.Db.Migrations
{
    public partial class AddTitleToArticle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "title",
                table: "article",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "title",
                table: "article");
        }
    }
}
