using Microsoft.EntityFrameworkCore.Migrations;

namespace CandidateTestService.Repository.Migrations
{
    public partial class update177 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Marked",
                table: "TestResults",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<float>(
                name: "EssayScore",
                table: "Question",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Marked",
                table: "TestResults");

            migrationBuilder.DropColumn(
                name: "EssayScore",
                table: "Question");
        }
    }
}
