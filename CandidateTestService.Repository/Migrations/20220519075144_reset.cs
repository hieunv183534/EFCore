using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CandidateTestService.Repository.Migrations
{
    public partial class reset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Question_Section_SectionId",
                table: "Question");

            migrationBuilder.DropForeignKey(
                name: "FK_Section_Question_QuestionId",
                table: "Section");

            migrationBuilder.DropIndex(
                name: "IX_Section_QuestionId",
                table: "Section");

            migrationBuilder.DropIndex(
                name: "IX_Question_SectionId",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "QuestionId",
                table: "Section");

            migrationBuilder.DropColumn(
                name: "SectionId",
                table: "Question");

            migrationBuilder.CreateTable(
                name: "QuestionSections",
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
                    table.PrimaryKey("PK_QuestionSections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionSections_Question_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Question",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QuestionSections_Section_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Section",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuestionSections_QuestionId",
                table: "QuestionSections",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionSections_SectionId",
                table: "QuestionSections",
                column: "SectionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuestionSections");

            migrationBuilder.AddColumn<byte[]>(
                name: "QuestionId",
                table: "Section",
                type: "varbinary(16)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "SectionId",
                table: "Question",
                type: "varbinary(16)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Section_QuestionId",
                table: "Section",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Question_SectionId",
                table: "Question",
                column: "SectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Question_Section_SectionId",
                table: "Question",
                column: "SectionId",
                principalTable: "Section",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Section_Question_QuestionId",
                table: "Section",
                column: "QuestionId",
                principalTable: "Question",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
