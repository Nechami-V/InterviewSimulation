using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace subWebTemech.data_access.migrations
{
    public partial class AddInterviewTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "experienceLevels");

            migrationBuilder.DropTable(
                name: "languages");

            migrationBuilder.CreateTable(
                name: "AnswerSimulations",
                columns: table => new
                {
                    AnswerSimulationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnswerText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsCorrect = table.Column<bool>(type: "bit", nullable: false),
                    Links = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnswerSimulations", x => x.AnswerSimulationID);
                });

            migrationBuilder.CreateTable(
                name: "InterviewSimulations",
                columns: table => new
                {
                    InterviewSimulationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InterviewSimulationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterviewSimulations", x => x.InterviewSimulationID);
                    table.ForeignKey(
                        name: "FK_InterviewSimulations_users_UserID",
                        column: x => x.UserID,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuestionSimulations",
                columns: table => new
                {
                    QuestionSimulationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hint = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionSimulations", x => x.QuestionSimulationID);
                });

            migrationBuilder.CreateTable(
                name: "QuestionAnswer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionSimulationID = table.Column<int>(type: "int", nullable: false),
                    AnswerSimulationID = table.Column<int>(type: "int", nullable: false),
                    InterviewSimulationID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionAnswer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionAnswer_AnswerSimulations_AnswerSimulationID",
                        column: x => x.AnswerSimulationID,
                        principalTable: "AnswerSimulations",
                        principalColumn: "AnswerSimulationID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuestionAnswer_InterviewSimulations_InterviewSimulationID",
                        column: x => x.InterviewSimulationID,
                        principalTable: "InterviewSimulations",
                        principalColumn: "InterviewSimulationID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuestionAnswer_QuestionSimulations_QuestionSimulationID",
                        column: x => x.QuestionSimulationID,
                        principalTable: "QuestionSimulations",
                        principalColumn: "QuestionSimulationID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InterviewSimulations_UserID",
                table: "InterviewSimulations",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionAnswer_AnswerSimulationID",
                table: "QuestionAnswer",
                column: "AnswerSimulationID");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionAnswer_InterviewSimulationID",
                table: "QuestionAnswer",
                column: "InterviewSimulationID");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionAnswer_QuestionSimulationID",
                table: "QuestionAnswer",
                column: "QuestionSimulationID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuestionAnswer");

            migrationBuilder.DropTable(
                name: "AnswerSimulations");

            migrationBuilder.DropTable(
                name: "InterviewSimulations");

            migrationBuilder.DropTable(
                name: "QuestionSimulations");

            migrationBuilder.CreateTable(
                name: "experienceLevels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_experienceLevels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "languages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_languages", x => x.Id);
                });
        }
    }
}
