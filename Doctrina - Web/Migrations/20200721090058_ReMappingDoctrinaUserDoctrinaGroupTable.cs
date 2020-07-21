using Microsoft.EntityFrameworkCore.Migrations;

namespace Doctrina___Web.Migrations
{
    public partial class ReMappingDoctrinaUserDoctrinaGroupTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoctrinaUserDoctrinaGroup_AspNetUsers_DoctrinaGroupId",
                table: "DoctrinaUserDoctrinaGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_DoctrinaUserDoctrinaGroup_DoctrinaGroups_DoctrinaUserId",
                table: "DoctrinaUserDoctrinaGroup");

            migrationBuilder.AddForeignKey(
                name: "FK_DoctrinaUserDoctrinaGroup_DoctrinaGroups_DoctrinaGroupId",
                table: "DoctrinaUserDoctrinaGroup",
                column: "DoctrinaGroupId",
                principalTable: "DoctrinaGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DoctrinaUserDoctrinaGroup_AspNetUsers_DoctrinaUserId",
                table: "DoctrinaUserDoctrinaGroup",
                column: "DoctrinaUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoctrinaUserDoctrinaGroup_DoctrinaGroups_DoctrinaGroupId",
                table: "DoctrinaUserDoctrinaGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_DoctrinaUserDoctrinaGroup_AspNetUsers_DoctrinaUserId",
                table: "DoctrinaUserDoctrinaGroup");

            migrationBuilder.AddForeignKey(
                name: "FK_DoctrinaUserDoctrinaGroup_AspNetUsers_DoctrinaGroupId",
                table: "DoctrinaUserDoctrinaGroup",
                column: "DoctrinaGroupId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DoctrinaUserDoctrinaGroup_DoctrinaGroups_DoctrinaUserId",
                table: "DoctrinaUserDoctrinaGroup",
                column: "DoctrinaUserId",
                principalTable: "DoctrinaGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
