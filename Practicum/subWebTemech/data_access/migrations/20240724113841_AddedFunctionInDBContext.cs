using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace subWebTemech.data_access.migrations
{
    public partial class AddedFunctionInDBContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ViewQuestion",
                columns: table => new
                {
                    InterviewId = table.Column<int>(type: "int", nullable: false),
                    QuestionsAndAnswersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ViewQuestion", x => new { x.InterviewId, x.QuestionsAndAnswersId });
                    table.ForeignKey(
                        name: "FK_ViewQuestion_Interview_InterviewId",
                        column: x => x.InterviewId,
                        principalTable: "Interview",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ViewQuestion_QuestionsAndAnswers_QuestionsAndAnswersId",
                        column: x => x.QuestionsAndAnswersId,
                        principalTable: "QuestionsAndAnswers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "InterviewsIndex",
                table: "Interview",
                columns: new[] { "InterviewDate", "UserId" });

            migrationBuilder.CreateIndex(
                name: "IX_ViewQuestion_QuestionsAndAnswersId",
                table: "ViewQuestion",
                column: "QuestionsAndAnswersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ViewQuestion");

            migrationBuilder.DropIndex(
                name: "InterviewsIndex",
                table: "Interview");
        }
    }
}
