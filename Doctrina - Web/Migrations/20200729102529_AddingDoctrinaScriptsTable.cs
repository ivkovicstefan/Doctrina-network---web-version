using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Doctrina___Web.Migrations
{
    public partial class AddingDoctrinaScriptsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DoctrinaScripts",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    CreatorId = table.Column<string>(nullable: true),
                    LastModifiedById = table.Column<string>(nullable: true),
                    FilePath = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateLastModified = table.Column<DateTime>(nullable: false),
                    DoctrinaGroupSectionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctrinaScripts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DoctrinaScripts_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DoctrinaScripts_DoctrinaGroupSections_DoctrinaGroupSectionId",
                        column: x => x.DoctrinaGroupSectionId,
                        principalTable: "DoctrinaGroupSections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DoctrinaScripts_AspNetUsers_LastModifiedById",
                        column: x => x.LastModifiedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DoctrinaScripts_CreatorId",
                table: "DoctrinaScripts",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctrinaScripts_DoctrinaGroupSectionId",
                table: "DoctrinaScripts",
                column: "DoctrinaGroupSectionId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctrinaScripts_LastModifiedById",
                table: "DoctrinaScripts",
                column: "LastModifiedById");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DoctrinaScripts");
        }
    }
}
