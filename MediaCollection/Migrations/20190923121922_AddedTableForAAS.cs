using Microsoft.EntityFrameworkCore.Migrations;

namespace MediaCollection.Migrations
{
    public partial class AddedTableForAAS : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ArtistAlbumSong",
                table: "ArtistAlbumSong");

            migrationBuilder.RenameTable(
                name: "ArtistAlbumSong",
                newName: "ArtistAlbumSongs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ArtistAlbumSongs",
                table: "ArtistAlbumSongs",
                columns: new[] { "AlbumId", "ArtistId", "SongId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ArtistAlbumSongs",
                table: "ArtistAlbumSongs");

            migrationBuilder.RenameTable(
                name: "ArtistAlbumSongs",
                newName: "ArtistAlbumSong");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ArtistAlbumSong",
                table: "ArtistAlbumSong",
                columns: new[] { "AlbumId", "ArtistId", "SongId" });
        }
    }
}
