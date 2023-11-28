using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataBaseConnection.Migrations
{
    public partial class APItest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NewsComments_Posts_NewsId",
                table: "NewsComments");

            migrationBuilder.DropTable(
                name: "ThreadComments");

            migrationBuilder.RenameColumn(
                name: "Thread_Title",
                table: "Posts",
                newName: "Blog_Title");

            migrationBuilder.RenameColumn(
                name: "Thread_Category",
                table: "Posts",
                newName: "Blog_Category");

            migrationBuilder.RenameColumn(
                name: "ThreadId",
                table: "Posts",
                newName: "BlogId");

            migrationBuilder.RenameColumn(
                name: "NewsId",
                table: "NewsComments",
                newName: "NewsPostId");

            migrationBuilder.RenameIndex(
                name: "IX_NewsComments_NewsId",
                table: "NewsComments",
                newName: "IX_NewsComments_NewsPostId");

            migrationBuilder.AlterColumn<int>(
                name: "Blog_Category",
                table: "Posts",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "BlogComments",
                columns: table => new
                {
                    BlogCommentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BlogPostId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogComments", x => x.BlogCommentId);
                    table.ForeignKey(
                        name: "FK_BlogComments_Posts_BlogPostId",
                        column: x => x.BlogPostId,
                        principalTable: "Posts",
                        principalColumn: "PostId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_BlogComments_BlogPostId",
                table: "BlogComments",
                column: "BlogPostId");

            migrationBuilder.AddForeignKey(
                name: "FK_NewsComments_Posts_NewsPostId",
                table: "NewsComments",
                column: "NewsPostId",
                principalTable: "Posts",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NewsComments_Posts_NewsPostId",
                table: "NewsComments");

            migrationBuilder.DropTable(
                name: "BlogComments");

            migrationBuilder.RenameColumn(
                name: "Blog_Title",
                table: "Posts",
                newName: "Thread_Title");

            migrationBuilder.RenameColumn(
                name: "Blog_Category",
                table: "Posts",
                newName: "Thread_Category");

            migrationBuilder.RenameColumn(
                name: "BlogId",
                table: "Posts",
                newName: "ThreadId");

            migrationBuilder.RenameColumn(
                name: "NewsPostId",
                table: "NewsComments",
                newName: "NewsId");

            migrationBuilder.RenameIndex(
                name: "IX_NewsComments_NewsPostId",
                table: "NewsComments",
                newName: "IX_NewsComments_NewsId");

            migrationBuilder.AlterColumn<string>(
                name: "Thread_Category",
                table: "Posts",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ThreadComments",
                columns: table => new
                {
                    ThreadCommentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ThreadId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThreadComments", x => x.ThreadCommentId);
                    table.ForeignKey(
                        name: "FK_ThreadComments_Posts_ThreadId",
                        column: x => x.ThreadId,
                        principalTable: "Posts",
                        principalColumn: "PostId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ThreadComments_ThreadId",
                table: "ThreadComments",
                column: "ThreadId");

            migrationBuilder.AddForeignKey(
                name: "FK_NewsComments_Posts_NewsId",
                table: "NewsComments",
                column: "NewsId",
                principalTable: "Posts",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
