using Microsoft.EntityFrameworkCore.Migrations;

namespace Doctrina___Web.Migrations
{
    public partial class AddedTwoFieldsToDoctrinaScriptsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FilePath",
                table: "DoctrinaScripts");

            migrationBuilder.AddColumn<string>(
                name: "AbsolutePath",
                table: "DoctrinaScripts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WebRootPath",
                table: "DoctrinaScripts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AbsolutePath",
                table: "DoctrinaScripts");

            migrationBuilder.DropColumn(
                name: "WebRootPath",
                table: "DoctrinaScripts");

            migrationBuilder.AddColumn<string>(
                name: "FilePath",
                table: "DoctrinaScripts",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
