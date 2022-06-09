using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class Init13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CaseTypeOfWork_Cases_CasesCaseId",
                table: "CaseTypeOfWork");

            migrationBuilder.RenameColumn(
                name: "CasesCaseId",
                table: "CaseTypeOfWork",
                newName: "CasesId");

            migrationBuilder.RenameColumn(
                name: "CaseId",
                table: "Cases",
                newName: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CaseTypeOfWork_Cases_CasesId",
                table: "CaseTypeOfWork",
                column: "CasesId",
                principalTable: "Cases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CaseTypeOfWork_Cases_CasesId",
                table: "CaseTypeOfWork");

            migrationBuilder.RenameColumn(
                name: "CasesId",
                table: "CaseTypeOfWork",
                newName: "CasesCaseId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Cases",
                newName: "CaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_CaseTypeOfWork_Cases_CasesCaseId",
                table: "CaseTypeOfWork",
                column: "CasesCaseId",
                principalTable: "Cases",
                principalColumn: "CaseId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
