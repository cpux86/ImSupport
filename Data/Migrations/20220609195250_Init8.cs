using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class Init8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CaseTypeOfWork_TypeOfWork_WorkDoneDescriptionId",
                table: "CaseTypeOfWork");

            migrationBuilder.RenameColumn(
                name: "WorkDoneDescriptionId",
                table: "CaseTypeOfWork",
                newName: "WorkDoneListId");

            migrationBuilder.RenameIndex(
                name: "IX_CaseTypeOfWork_WorkDoneDescriptionId",
                table: "CaseTypeOfWork",
                newName: "IX_CaseTypeOfWork_WorkDoneListId");

            migrationBuilder.AddForeignKey(
                name: "FK_CaseTypeOfWork_TypeOfWork_WorkDoneListId",
                table: "CaseTypeOfWork",
                column: "WorkDoneListId",
                principalTable: "TypeOfWork",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CaseTypeOfWork_TypeOfWork_WorkDoneListId",
                table: "CaseTypeOfWork");

            migrationBuilder.RenameColumn(
                name: "WorkDoneListId",
                table: "CaseTypeOfWork",
                newName: "WorkDoneDescriptionId");

            migrationBuilder.RenameIndex(
                name: "IX_CaseTypeOfWork_WorkDoneListId",
                table: "CaseTypeOfWork",
                newName: "IX_CaseTypeOfWork_WorkDoneDescriptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_CaseTypeOfWork_TypeOfWork_WorkDoneDescriptionId",
                table: "CaseTypeOfWork",
                column: "WorkDoneDescriptionId",
                principalTable: "TypeOfWork",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
