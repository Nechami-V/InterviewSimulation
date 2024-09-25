using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace subWebTemech.data_access.migrations
{
    public partial class ChangedFKForJobSudmitted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobSudmitted_job_jobID",
                table: "JobSudmitted");

            migrationBuilder.DropIndex(
                name: "IX_JobSudmitted_jobID",
                table: "JobSudmitted");

            migrationBuilder.AddColumn<int>(
                name: "userIdId",
                table: "JobSudmitted",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_JobSudmitted_userIdId",
                table: "JobSudmitted",
                column: "userIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobSudmitted_users_userIdId",
                table: "JobSudmitted",
                column: "userIdId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobSudmitted_users_userIdId",
                table: "JobSudmitted");

            migrationBuilder.DropIndex(
                name: "IX_JobSudmitted_userIdId",
                table: "JobSudmitted");

            migrationBuilder.DropColumn(
                name: "userIdId",
                table: "JobSudmitted");

            migrationBuilder.CreateIndex(
                name: "IX_JobSudmitted_jobID",
                table: "JobSudmitted",
                column: "jobID");

            migrationBuilder.AddForeignKey(
                name: "FK_JobSudmitted_job_jobID",
                table: "JobSudmitted",
                column: "jobID",
                principalTable: "job",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
