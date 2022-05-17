using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CandidateTestService.Repository.Migrations
{
    public partial class upup333 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sections_Questions_QuestionId",
                table: "Sections");

            migrationBuilder.DropIndex(
                name: "IX_Sections_QuestionId",
                table: "Sections");

            migrationBuilder.DropColumn(
                name: "QuestionId",
                table: "Sections");

            migrationBuilder.CreateTable(
                name: "QuestionSection",
                columns: table => new
                {
                    Id = table.Column<byte[]>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    ModifiedAt = table.Column<DateTime>(nullable: true),
                    QuestionId = table.Column<byte[]>(nullable: true),
                    SectionId = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionSection", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionSection_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QuestionSection_Sections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Sections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuestionSection_QuestionId",
                table: "QuestionSection",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionSection_SectionId",
                table: "QuestionSection",
                column: "SectionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuestionSection");

            migrationBuilder.AddColumn<byte[]>(
                name: "QuestionId",
                table: "Sections",
                type: "varbinary(16)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sections_QuestionId",
                table: "Sections",
                column: "QuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sections_Questions_QuestionId",
                table: "Sections",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
