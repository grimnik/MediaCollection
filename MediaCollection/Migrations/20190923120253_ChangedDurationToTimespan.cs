using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MediaCollection.Migrations
{
    public partial class ChangedDurationToTimespan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeSpan>(
                name: "Duration",
                table: "Songs",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "ReleaseDate",
                table: "Albums",
                nullable: false,
                oldClrType: typeof(DateTime));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Duration",
                table: "Songs",
                nullable: false,
                oldClrType: typeof(TimeSpan));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReleaseDate",
                table: "Albums",
                nullable: false,
                oldClrType: typeof(TimeSpan));
        }
    }
}
