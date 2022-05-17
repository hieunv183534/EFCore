using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CandidateTestService.Repository.Migrations
{
    public partial class upup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Sections_TestSectionId",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_TestSectionId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "TestSectionId",
                table: "Questions");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "TestSectionId",
                table: "Questions",
                type: "varbinary(16)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Questions_TestSectionId",
                table: "Questions",
                column: "TestSectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Sections_TestSectionId",
                table: "Questions",
                column: "TestSectionId",
                principalTable: "Sections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
