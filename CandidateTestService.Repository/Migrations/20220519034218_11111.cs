using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CandidateTestService.Repository.Migrations
{
    public partial class _11111 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Section_Test_TestId",
                table: "Section");

            migrationBuilder.DropForeignKey(
                name: "FK_TestAccount_Account_AccountId",
                table: "TestAccount");

            migrationBuilder.DropForeignKey(
                name: "FK_TestAccount_Test_TestId",
                table: "TestAccount");

            migrationBuilder.DropForeignKey(
                name: "FK_TestResult_Account_AccountId",
                table: "TestResult");

            migrationBuilder.DropForeignKey(
                name: "FK_TestResult_Test_TestId",
                table: "TestResult");

            migrationBuilder.DropTable(
                name: "QuestionSection");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TestResult",
                table: "TestResult");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TestAccount",
                table: "TestAccount");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Test",
                table: "Test");

            migrationBuilder.RenameTable(
                name: "TestResult",
                newName: "TestResults");

            migrationBuilder.RenameTable(
                name: "TestAccount",
                newName: "TestAccounts");

            migrationBuilder.RenameTable(
                name: "Test",
                newName: "Tests");

            migrationBuilder.RenameIndex(
                name: "IX_TestResult_TestId",
                table: "TestResults",
                newName: "IX_TestResults_TestId");

            migrationBuilder.RenameIndex(
                name: "IX_TestResult_AccountId",
                table: "TestResults",
                newName: "IX_TestResults_AccountId");

            migrationBuilder.RenameIndex(
                name: "IX_TestAccount_TestId",
                table: "TestAccounts",
                newName: "IX_TestAccounts_TestId");

            migrationBuilder.RenameIndex(
                name: "IX_TestAccount_AccountId",
                table: "TestAccounts",
                newName: "IX_TestAccounts_AccountId");

            migrationBuilder.AddColumn<byte[]>(
                name: "QuestionId",
                table: "Section",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "SectionId",
                table: "Question",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TestResults",
                table: "TestResults",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TestAccounts",
                table: "TestAccounts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tests",
                table: "Tests",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "TokenAccounts",
                columns: table => new
                {
                    Id = table.Column<byte[]>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    ModifiedAt = table.Column<DateTime>(nullable: true),
                    Token = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TokenAccounts", x => x.Id);
                });

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

            migrationBuilder.AddForeignKey(
                name: "FK_Section_Tests_TestId",
                table: "Section",
                column: "TestId",
                principalTable: "Tests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TestAccounts_Account_AccountId",
                table: "TestAccounts",
                column: "AccountId",
                principalTable: "Account",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TestAccounts_Tests_TestId",
                table: "TestAccounts",
                column: "TestId",
                principalTable: "Tests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TestResults_Account_AccountId",
                table: "TestResults",
                column: "AccountId",
                principalTable: "Account",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TestResults_Tests_TestId",
                table: "TestResults",
                column: "TestId",
                principalTable: "Tests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Question_Section_SectionId",
                table: "Question");

            migrationBuilder.DropForeignKey(
                name: "FK_Section_Question_QuestionId",
                table: "Section");

            migrationBuilder.DropForeignKey(
                name: "FK_Section_Tests_TestId",
                table: "Section");

            migrationBuilder.DropForeignKey(
                name: "FK_TestAccounts_Account_AccountId",
                table: "TestAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_TestAccounts_Tests_TestId",
                table: "TestAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_TestResults_Account_AccountId",
                table: "TestResults");

            migrationBuilder.DropForeignKey(
                name: "FK_TestResults_Tests_TestId",
                table: "TestResults");

            migrationBuilder.DropTable(
                name: "TokenAccounts");

            migrationBuilder.DropIndex(
                name: "IX_Section_QuestionId",
                table: "Section");

            migrationBuilder.DropIndex(
                name: "IX_Question_SectionId",
                table: "Question");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tests",
                table: "Tests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TestResults",
                table: "TestResults");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TestAccounts",
                table: "TestAccounts");

            migrationBuilder.DropColumn(
                name: "QuestionId",
                table: "Section");

            migrationBuilder.DropColumn(
                name: "SectionId",
                table: "Question");

            migrationBuilder.RenameTable(
                name: "Tests",
                newName: "Test");

            migrationBuilder.RenameTable(
                name: "TestResults",
                newName: "TestResult");

            migrationBuilder.RenameTable(
                name: "TestAccounts",
                newName: "TestAccount");

            migrationBuilder.RenameIndex(
                name: "IX_TestResults_TestId",
                table: "TestResult",
                newName: "IX_TestResult_TestId");

            migrationBuilder.RenameIndex(
                name: "IX_TestResults_AccountId",
                table: "TestResult",
                newName: "IX_TestResult_AccountId");

            migrationBuilder.RenameIndex(
                name: "IX_TestAccounts_TestId",
                table: "TestAccount",
                newName: "IX_TestAccount_TestId");

            migrationBuilder.RenameIndex(
                name: "IX_TestAccounts_AccountId",
                table: "TestAccount",
                newName: "IX_TestAccount_AccountId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Test",
                table: "Test",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TestResult",
                table: "TestResult",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TestAccount",
                table: "TestAccount",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "QuestionSection",
                columns: table => new
                {
                    Id = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    QuestionId = table.Column<byte[]>(type: "varbinary(16)", nullable: true),
                    SectionId = table.Column<byte[]>(type: "varbinary(16)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionSection", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionSection_Question_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Question",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QuestionSection_Section_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Section",
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

            migrationBuilder.AddForeignKey(
                name: "FK_Section_Test_TestId",
                table: "Section",
                column: "TestId",
                principalTable: "Test",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TestAccount_Account_AccountId",
                table: "TestAccount",
                column: "AccountId",
                principalTable: "Account",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TestAccount_Test_TestId",
                table: "TestAccount",
                column: "TestId",
                principalTable: "Test",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TestResult_Account_AccountId",
                table: "TestResult",
                column: "AccountId",
                principalTable: "Account",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TestResult_Test_TestId",
                table: "TestResult",
                column: "TestId",
                principalTable: "Test",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
