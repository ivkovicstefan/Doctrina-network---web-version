using Microsoft.EntityFrameworkCore.Migrations;

namespace Doctrina___Web.Migrations
{
    public partial class AddingColumnsToFriendshipTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsInvitePending",
                table: "Friendship",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsRequestPending",
                table: "Friendship",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsInvitePending",
                table: "Friendship");

            migrationBuilder.DropColumn(
                name: "IsRequestPending",
                table: "Friendship");
        }
    }
}
