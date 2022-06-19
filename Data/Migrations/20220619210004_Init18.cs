using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class Init18 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CaseTypeOfWork");

            migrationBuilder.CreateTable(
                name: "CaseWorksList",
                columns: table => new
                {
                    CasesId = table.Column<int>(type: "INTEGER", nullable: false),
                    TypeOfWorksId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseWorksList", x => new { x.CasesId, x.TypeOfWorksId });
                    table.ForeignKey(
                        name: "FK_CaseWorksList_Cases_CasesId",
                        column: x => x.CasesId,
                        principalTable: "Cases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CaseWorksList_TypeOfWorks_TypeOfWorksId",
                        column: x => x.TypeOfWorksId,
                        principalTable: "WorksLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CaseWorksList_TypeOfWorksId",
                table: "CaseWorksList",
                column: "TypeOfWorksId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CaseWorksList");

            migrationBuilder.CreateTable(
                name: "CaseTypeOfWork",
                columns: table => new
                {
                    CasesId = table.Column<int>(type: "INTEGER", nullable: false),
                    TypeOfWorksId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseTypeOfWork", x => new { x.CasesId, x.TypeOfWorksId });
                    table.ForeignKey(
                        name: "FK_CaseTypeOfWork_Cases_CasesId",
                        column: x => x.CasesId,
                        principalTable: "Cases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CaseTypeOfWork_TypeOfWorks_TypeOfWorksId",
                        column: x => x.TypeOfWorksId,
                        principalTable: "WorksLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CaseTypeOfWork_TypeOfWorksId",
                table: "CaseTypeOfWork",
                column: "TypeOfWorksId");
        }
    }
}
