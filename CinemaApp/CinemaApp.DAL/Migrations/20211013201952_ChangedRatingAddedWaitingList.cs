using Microsoft.EntityFrameworkCore.Migrations;

namespace CinemaApp.DAL.Migrations
{
    public partial class ChangedRatingAddedWaitingList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Rating",
                table: "Movies",
                newName: "RatingsSum");

            migrationBuilder.AddColumn<int>(
                name: "RatingsNumber",
                table: "Movies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "MovieWaitingList",
                columns: table => new
                {
                    MovieWaitingListId = table.Column<int>(type: "int", nullable: false),
                    UserWaitingListId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieWaitingList", x => new { x.MovieWaitingListId, x.UserWaitingListId });
                    table.ForeignKey(
                        name: "FK_MovieWaitingList_Movies_MovieWaitingListId",
                        column: x => x.MovieWaitingListId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieWaitingList_Users_UserWaitingListId",
                        column: x => x.UserWaitingListId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieWaitingList_UserWaitingListId",
                table: "MovieWaitingList",
                column: "UserWaitingListId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieWaitingList");

            migrationBuilder.DropColumn(
                name: "RatingsNumber",
                table: "Movies");

            migrationBuilder.RenameColumn(
                name: "RatingsSum",
                table: "Movies",
                newName: "Rating");
        }
    }
}
