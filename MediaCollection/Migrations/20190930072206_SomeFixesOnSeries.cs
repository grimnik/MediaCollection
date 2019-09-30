using Microsoft.EntityFrameworkCore.Migrations;

namespace MediaCollection.Migrations
{
    public partial class SomeFixesOnSeries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Beschrijving",
                table: "Afleveringen",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Beschrijving",
                table: "Afleveringen");
        }
    }
}
