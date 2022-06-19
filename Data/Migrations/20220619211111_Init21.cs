using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class Init21 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CaseWorksList_WorksList_WorksListsId",
                table: "CaseWorksList");

            migrationBuilder.RenameColumn(
                name: "WorksListsId",
                table: "CaseWorksList",
                newName: "WorksListId");

            migrationBuilder.RenameIndex(
                name: "IX_CaseWorksList_WorksListsId",
                table: "CaseWorksList",
                newName: "IX_CaseWorksList_WorksListId");

            migrationBuilder.AddForeignKey(
                name: "FK_CaseWorksList_WorksList_WorksListId",
                table: "CaseWorksList",
                column: "WorksListId",
                principalTable: "WorksList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CaseWorksList_WorksList_WorksListId",
                table: "CaseWorksList");

            migrationBuilder.RenameColumn(
                name: "WorksListId",
                table: "CaseWorksList",
                newName: "WorksListsId");

            migrationBuilder.RenameIndex(
                name: "IX_CaseWorksList_WorksListId",
                table: "CaseWorksList",
                newName: "IX_CaseWorksList_WorksListsId");

            migrationBuilder.AddForeignKey(
                name: "FK_CaseWorksList_WorksList_WorksListsId",
                table: "CaseWorksList",
                column: "WorksListsId",
                principalTable: "WorksList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
