using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace subWebTemech.data_access.migrations
{
    public partial class AddedLinesInAnswerSimulationTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "QuestionSimulation",
                columns: table => new
                {
                    QuestionSimulationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hint = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    interviewSimulationID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionSimulation", x => x.QuestionSimulationID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnswerSimulation_QuestionSimulationID",
                table: "AnswerSimulation",
                column: "QuestionSimulationID");

            migrationBuilder.AddForeignKey(
                name: "FK_AnswerSimulation_QuestionSimulation_QuestionSimulationID",
                table: "AnswerSimulation",
                column: "QuestionSimulationID",
                principalTable: "QuestionSimulation",
                principalColumn: "QuestionSimulationID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnswerSimulation_QuestionSimulation_QuestionSimulationID",
                table: "AnswerSimulation");

            migrationBuilder.DropTable(
                name: "QuestionSimulation");

            migrationBuilder.DropIndex(
                name: "IX_AnswerSimulation_QuestionSimulationID",
                table: "AnswerSimulation");
        }
    }
}
