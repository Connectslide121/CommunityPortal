using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataBaseConnection.Migrations
{
    public partial class addcommentmethods : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Category",
                table: "Posts",
                newName: "NewsCategory");

            migrationBuilder.RenameColumn(
                name: "Blog_Category",
                table: "Posts",
                newName: "BlogCategory");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NewsCategory",
                table: "Posts",
                newName: "Category");

            migrationBuilder.RenameColumn(
                name: "BlogCategory",
                table: "Posts",
                newName: "Blog_Category");
        }
    }
}
