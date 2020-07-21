using Microsoft.EntityFrameworkCore.Migrations;

namespace Doctrina___Web.Migrations
{
    public partial class AddingUserGroupM2MRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DoctrinaGroups",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctrinaGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DoctrinaGroupSections",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    DoctrinaGroupId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctrinaGroupSections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DoctrinaGroupSections_DoctrinaGroups_DoctrinaGroupId",
                        column: x => x.DoctrinaGroupId,
                        principalTable: "DoctrinaGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DoctrinaUserDoctrinaGroup",
                columns: table => new
                {
                    DoctrinaUserId = table.Column<string>(nullable: false),
                    DoctrinaGroupId = table.Column<string>(nullable: false),
                    IsAdmin = table.Column<bool>(nullable: false),
                    IsInvitePending = table.Column<bool>(nullable: false),
                    IsRequestPending = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctrinaUserDoctrinaGroup", x => new { x.DoctrinaUserId, x.DoctrinaGroupId });
                    table.ForeignKey(
                        name: "FK_DoctrinaUserDoctrinaGroup_AspNetUsers_DoctrinaGroupId",
                        column: x => x.DoctrinaGroupId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DoctrinaUserDoctrinaGroup_DoctrinaGroups_DoctrinaUserId",
                        column: x => x.DoctrinaUserId,
                        principalTable: "DoctrinaGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DoctrinaGroupSections_DoctrinaGroupId",
                table: "DoctrinaGroupSections",
                column: "DoctrinaGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctrinaUserDoctrinaGroup_DoctrinaGroupId",
                table: "DoctrinaUserDoctrinaGroup",
                column: "DoctrinaGroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DoctrinaGroupSections");

            migrationBuilder.DropTable(
                name: "DoctrinaUserDoctrinaGroup");

            migrationBuilder.DropTable(
                name: "DoctrinaGroups");
        }
    }
}
