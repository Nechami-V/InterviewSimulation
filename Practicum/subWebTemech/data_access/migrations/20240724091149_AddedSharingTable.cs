using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace subWebTemech.data_access.migrations
{
    public partial class AddedSharingTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "sharings",
                columns: table => new
                {
                    SharingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShareMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CVId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sharings", x => x.SharingId);
                    table.ForeignKey(
                        name: "FK_sharings_CV_CVId",
                        column: x => x.CVId,
                        principalTable: "CV",
                        principalColumn: "CVId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_sharings_CVId",
                table: "sharings",
                column: "CVId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "sharings");
        }
    }
}
