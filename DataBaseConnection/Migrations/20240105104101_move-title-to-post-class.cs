using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataBaseConnection.Migrations
{
    public partial class movetitletopostclass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Blog_Title",
                table: "Posts");

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Title",
                keyValue: null,
                column: "Title",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Posts",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Posts",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Blog_Title",
                table: "Posts",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
