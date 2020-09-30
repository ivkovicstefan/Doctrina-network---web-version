using Microsoft.EntityFrameworkCore.Migrations;

namespace Doctrina___Web.Migrations
{
    public partial class AddDoctrinaSchoolTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DoctrinaSchools",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctrinaSchools", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DoctrinaUserDoctrinaSchool",
                columns: table => new
                {
                    DoctrinaUserId = table.Column<string>(nullable: false),
                    DoctrinaSchoolId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctrinaUserDoctrinaSchool", x => new { x.DoctrinaUserId, x.DoctrinaSchoolId });
                    table.ForeignKey(
                        name: "FK_DoctrinaUserDoctrinaSchool_DoctrinaSchools_DoctrinaSchoolId",
                        column: x => x.DoctrinaSchoolId,
                        principalTable: "DoctrinaSchools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DoctrinaUserDoctrinaSchool_AspNetUsers_DoctrinaUserId",
                        column: x => x.DoctrinaUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DoctrinaUserDoctrinaSchool_DoctrinaSchoolId",
                table: "DoctrinaUserDoctrinaSchool",
                column: "DoctrinaSchoolId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DoctrinaUserDoctrinaSchool");

            migrationBuilder.DropTable(
                name: "DoctrinaSchools");
        }
    }
}
