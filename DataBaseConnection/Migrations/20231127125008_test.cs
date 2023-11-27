using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataBaseConnection.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Posts_ThreadId",
                table: "Comments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comments",
                table: "Comments");

            migrationBuilder.RenameTable(
                name: "Comments",
                newName: "ThreadComments");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_ThreadId",
                table: "ThreadComments",
                newName: "IX_ThreadComments_ThreadId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ThreadComments",
                table: "ThreadComments",
                column: "ThreadCommentId");

            migrationBuilder.AddForeignKey(
                name: "FK_ThreadComments_Posts_ThreadId",
                table: "ThreadComments",
                column: "ThreadId",
                principalTable: "Posts",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ThreadComments_Posts_ThreadId",
                table: "ThreadComments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ThreadComments",
                table: "ThreadComments");

            migrationBuilder.RenameTable(
                name: "ThreadComments",
                newName: "Comments");

            migrationBuilder.RenameIndex(
                name: "IX_ThreadComments_ThreadId",
                table: "Comments",
                newName: "IX_Comments_ThreadId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comments",
                table: "Comments",
                column: "ThreadCommentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Posts_ThreadId",
                table: "Comments",
                column: "ThreadId",
                principalTable: "Posts",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
