using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class Init19 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CaseWorksList_TypeOfWorks_TypeOfWorksId",
                table: "CaseWorksList");

            migrationBuilder.RenameColumn(
                name: "TypeOfWorksId",
                table: "CaseWorksList",
                newName: "WorksListsId");

            migrationBuilder.RenameIndex(
                name: "IX_CaseWorksList_TypeOfWorksId",
                table: "CaseWorksList",
                newName: "IX_CaseWorksList_WorksListsId");

            migrationBuilder.AddForeignKey(
                name: "FK_CaseWorksList_TypeOfWorks_WorksListsId",
                table: "CaseWorksList",
                column: "WorksListsId",
                principalTable: "TypeOfWorks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CaseWorksList_TypeOfWorks_WorksListsId",
                table: "CaseWorksList");

            migrationBuilder.RenameColumn(
                name: "WorksListsId",
                table: "CaseWorksList",
                newName: "TypeOfWorksId");

            migrationBuilder.RenameIndex(
                name: "IX_CaseWorksList_WorksListsId",
                table: "CaseWorksList",
                newName: "IX_CaseWorksList_TypeOfWorksId");

            migrationBuilder.AddForeignKey(
                name: "FK_CaseWorksList_TypeOfWorks_TypeOfWorksId",
                table: "CaseWorksList",
                column: "TypeOfWorksId",
                principalTable: "TypeOfWorks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
