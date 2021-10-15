using Microsoft.EntityFrameworkCore.Migrations;

namespace CinemaApp.DAL.Migrations
{
    public partial class ChangedFieldNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieWaitingList_Movies_MovieWaitingListId",
                table: "MovieWaitingList");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieWaitingList_Users_UserWaitingListId",
                table: "MovieWaitingList");

            migrationBuilder.RenameColumn(
                name: "UserWaitingListId",
                table: "MovieWaitingList",
                newName: "WaitingUsersId");

            migrationBuilder.RenameColumn(
                name: "MovieWaitingListId",
                table: "MovieWaitingList",
                newName: "ExpectedMoviesId");

            migrationBuilder.RenameIndex(
                name: "IX_MovieWaitingList_UserWaitingListId",
                table: "MovieWaitingList",
                newName: "IX_MovieWaitingList_WaitingUsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieWaitingList_Movies_ExpectedMoviesId",
                table: "MovieWaitingList",
                column: "ExpectedMoviesId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieWaitingList_Users_WaitingUsersId",
                table: "MovieWaitingList",
                column: "WaitingUsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieWaitingList_Movies_ExpectedMoviesId",
                table: "MovieWaitingList");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieWaitingList_Users_WaitingUsersId",
                table: "MovieWaitingList");

            migrationBuilder.RenameColumn(
                name: "WaitingUsersId",
                table: "MovieWaitingList",
                newName: "UserWaitingListId");

            migrationBuilder.RenameColumn(
                name: "ExpectedMoviesId",
                table: "MovieWaitingList",
                newName: "MovieWaitingListId");

            migrationBuilder.RenameIndex(
                name: "IX_MovieWaitingList_WaitingUsersId",
                table: "MovieWaitingList",
                newName: "IX_MovieWaitingList_UserWaitingListId");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieWaitingList_Movies_MovieWaitingListId",
                table: "MovieWaitingList",
                column: "MovieWaitingListId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieWaitingList_Users_UserWaitingListId",
                table: "MovieWaitingList",
                column: "UserWaitingListId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
