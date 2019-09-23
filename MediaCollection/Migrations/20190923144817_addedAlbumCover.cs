using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MediaCollection.Migrations
{
    public partial class addedAlbumCover : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Cover",
                table: "Albums",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cover",
                table: "Albums");
        }
    }
}
