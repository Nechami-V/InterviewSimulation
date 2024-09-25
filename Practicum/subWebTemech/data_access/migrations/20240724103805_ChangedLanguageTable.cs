using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace subWebTemech.data_access.migrations
{
    public partial class ChangedLanguageTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_TranslateCV_LanguageId",
                table: "TranslateCV",
                column: "LanguageId");

            migrationBuilder.AddForeignKey(
                name: "FK_TranslateCV_languages_LanguageId",
                table: "TranslateCV",
                column: "LanguageId",
                principalTable: "languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TranslateCV_languages_LanguageId",
                table: "TranslateCV");

            migrationBuilder.DropIndex(
                name: "IX_TranslateCV_LanguageId",
                table: "TranslateCV");
        }
    }
}
