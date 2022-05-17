using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CandidateTestService.Repository.Migrations
{
    public partial class upup11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "QuestionId",
                table: "Sections",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
