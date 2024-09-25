using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace subWebTemech.data_access.migrations
{
    public partial class AddeInterviewSimulationTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InterviewSimulation",
                columns: table => new
                {
                    InterviewSimulationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InterviewSimulationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterviewSimulation", x => x.InterviewSimulationID);
                    table.ForeignKey(
                        name: "FK_InterviewSimulation_users_UserID",
                        column: x => x.UserID,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnswerSimulation_InterviewSimulationID",
                table: "AnswerSimulation",
                column: "InterviewSimulationID");

            migrationBuilder.CreateIndex(
                name: "IX_InterviewSimulation_UserID",
                table: "InterviewSimulation",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_AnswerSimulation_InterviewSimulation_InterviewSimulationID",
                table: "AnswerSimulation",
                column: "InterviewSimulationID",
                principalTable: "InterviewSimulation",
                principalColumn: "InterviewSimulationID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnswerSimulation_InterviewSimulation_InterviewSimulationID",
                table: "AnswerSimulation");

            migrationBuilder.DropTable(
                name: "InterviewSimulation");

            migrationBuilder.DropIndex(
                name: "IX_AnswerSimulation_InterviewSimulationID",
                table: "AnswerSimulation");
        }
    }
}
