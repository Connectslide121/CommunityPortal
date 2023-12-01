using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataBaseConnection.Migrations
{
    public partial class AddListOfEventsAttendedInUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Events_EventId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_EventId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "Users");

            migrationBuilder.CreateTable(
                name: "EventUser",
                columns: table => new
                {
                    AttendantsUserId = table.Column<int>(type: "int", nullable: false),
                    EventsAttendedEventId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventUser", x => new { x.AttendantsUserId, x.EventsAttendedEventId });
                    table.ForeignKey(
                        name: "FK_EventUser_Events_EventsAttendedEventId",
                        column: x => x.EventsAttendedEventId,
                        principalTable: "Events",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventUser_Users_AttendantsUserId",
                        column: x => x.AttendantsUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_EventUser_EventsAttendedEventId",
                table: "EventUser",
                column: "EventsAttendedEventId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventUser");

            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_EventId",
                table: "Users",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Events_EventId",
                table: "Users",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "EventId");
        }
    }
}
