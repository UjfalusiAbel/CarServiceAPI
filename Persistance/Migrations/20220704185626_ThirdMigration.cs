using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistance.Migrations
{
    public partial class ThirdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Location",
                table: "Services",
                newName: "Town");

            migrationBuilder.AddColumn<string>(
                name: "County",
                table: "Services",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "County",
                table: "Services");

            migrationBuilder.RenameColumn(
                name: "Town",
                table: "Services",
                newName: "Location");
        }
    }
}
