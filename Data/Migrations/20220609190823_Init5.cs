using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class Init5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WorkDoneDescription",
                table: "Cases");

            migrationBuilder.CreateTable(
                name: "TypeOfWork",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeOfWork", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CaseTypeOfWork",
                columns: table => new
                {
                    CasesCaseId = table.Column<int>(type: "INTEGER", nullable: false),
                    WorkDoneDescriptionId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseTypeOfWork", x => new { x.CasesCaseId, x.WorkDoneDescriptionId });
                    table.ForeignKey(
                        name: "FK_CaseTypeOfWork_Cases_CasesCaseId",
                        column: x => x.CasesCaseId,
                        principalTable: "Cases",
                        principalColumn: "CaseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CaseTypeOfWork_TypeOfWork_WorkDoneDescriptionId",
                        column: x => x.WorkDoneDescriptionId,
                        principalTable: "TypeOfWork",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CaseTypeOfWork_WorkDoneDescriptionId",
                table: "CaseTypeOfWork",
                column: "WorkDoneDescriptionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CaseTypeOfWork");

            migrationBuilder.DropTable(
                name: "TypeOfWork");

            migrationBuilder.AddColumn<string>(
                name: "WorkDoneDescription",
                table: "Cases",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
