using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class Init20 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CaseWorksList_WorksLists_WorksListsId",
                table: "CaseWorksList");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorksLists",
                table: "WorksLists");

            migrationBuilder.RenameTable(
                name: "WorksLists",
                newName: "WorksList");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorksList",
                table: "WorksList",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CaseWorksList_WorksList_WorksListsId",
                table: "CaseWorksList",
                column: "WorksListsId",
                principalTable: "WorksList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CaseWorksList_WorksList_WorksListsId",
                table: "CaseWorksList");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorksList",
                table: "WorksList");

            migrationBuilder.RenameTable(
                name: "WorksList",
                newName: "WorksLists");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorksLists",
                table: "WorksLists",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CaseWorksList_WorksLists_WorksListsId",
                table: "CaseWorksList",
                column: "WorksListsId",
                principalTable: "WorksLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
