using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace subWebTemech.data_access.migrations
{
    public partial class removeQuestionsAnswersAndInterviewsAndAddQuestionAnswerד : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_job_UserProfile_UserProfileID",
                table: "job");

            migrationBuilder.DropForeignKey(
                name: "FK_JobSubCategory_job_jobId",
                table: "JobSubCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_job",
                table: "job");

            migrationBuilder.RenameTable(
                name: "job",
                newName: "Job");

            migrationBuilder.RenameIndex(
                name: "IX_job_UserProfileID",
                table: "Job",
                newName: "IX_Job_UserProfileID");

            migrationBuilder.AddColumn<bool>(
                name: "IsGoogleAccount",
                table: "users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Job",
                table: "Job",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    LanguageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LanguageName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.LanguageId);
                });

            migrationBuilder.CreateTable(
                name: "cVs",
                columns: table => new
                {
                    CVId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RatingId = table.Column<int>(type: "int", nullable: false),
                    TranslateCVId = table.Column<int>(type: "int", nullable: false),
                    PdfFile = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    DocxFile = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    UploadDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AmountOfCV = table.Column<int>(type: "int", nullable: false),
                    Favorite = table.Column<bool>(type: "bit", nullable: false),
                    TransCVLanguageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cVs", x => x.CVId);
                    table.ForeignKey(
                        name: "FK_cVs_Languages_TransCVLanguageId",
                        column: x => x.TransCVLanguageId,
                        principalTable: "Languages",
                        principalColumn: "LanguageId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cVs_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TranslateCV",
                columns: table => new
                {
                    TranslateCVId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    CVId = table.Column<int>(type: "int", nullable: false),
                    CVId1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TranslateCV", x => x.TranslateCVId);
                    table.ForeignKey(
                        name: "FK_TranslateCV_cVs_CVId1",
                        column: x => x.CVId1,
                        principalTable: "cVs",
                        principalColumn: "CVId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TranslateCV_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "LanguageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cVs_TransCVLanguageId",
                table: "cVs",
                column: "TransCVLanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_cVs_UserId",
                table: "cVs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TranslateCV_CVId1",
                table: "TranslateCV",
                column: "CVId1");

            migrationBuilder.CreateIndex(
                name: "IX_TranslateCV_LanguageId",
                table: "TranslateCV",
                column: "LanguageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Job_UserProfile_UserProfileID",
                table: "Job",
                column: "UserProfileID",
                principalTable: "UserProfile",
                principalColumn: "UserProfileID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobSubCategory_Job_jobId",
                table: "JobSubCategory",
                column: "jobId",
                principalTable: "Job",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Job_UserProfile_UserProfileID",
                table: "Job");

            migrationBuilder.DropForeignKey(
                name: "FK_JobSubCategory_Job_jobId",
                table: "JobSubCategory");

            migrationBuilder.DropTable(
                name: "TranslateCV");

            migrationBuilder.DropTable(
                name: "cVs");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Job",
                table: "Job");

            migrationBuilder.DropColumn(
                name: "IsGoogleAccount",
                table: "users");

            migrationBuilder.RenameTable(
                name: "Job",
                newName: "job");

            migrationBuilder.RenameIndex(
                name: "IX_Job_UserProfileID",
                table: "job",
                newName: "IX_job_UserProfileID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_job",
                table: "job",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_job_UserProfile_UserProfileID",
                table: "job",
                column: "UserProfileID",
                principalTable: "UserProfile",
                principalColumn: "UserProfileID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobSubCategory_job_jobId",
                table: "JobSubCategory",
                column: "jobId",
                principalTable: "job",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
