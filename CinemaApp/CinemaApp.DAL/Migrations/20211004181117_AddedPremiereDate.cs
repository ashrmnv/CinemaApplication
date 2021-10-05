using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CinemaApp.DAL.Migrations
{
    public partial class AddedPremiereDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "PremiereDate",
                table: "Movies",
                type: "smalldatetime",
                nullable: false,
                defaultValue: DateTime.Now);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PremiereDate",
                table: "Movies");
        }
    }
}
