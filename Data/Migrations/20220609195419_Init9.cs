using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class Init9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CaseTypeOfWork_TypeOfWork_WorkDoneListId",
                table: "CaseTypeOfWork");

            migrationBuilder.RenameColumn(
                name: "WorkDoneListId",
                table: "CaseTypeOfWork",
                newName: "WorkDoneDescriptionListId");

            migrationBuilder.RenameIndex(
                name: "IX_CaseTypeOfWork_WorkDoneListId",
                table: "CaseTypeOfWork",
                newName: "IX_CaseTypeOfWork_WorkDoneDescriptionListId");

            migrationBuilder.AddForeignKey(
                name: "FK_CaseTypeOfWork_TypeOfWork_WorkDoneDescriptionListId",
                table: "CaseTypeOfWork",
                column: "WorkDoneDescriptionListId",
                principalTable: "TypeOfWork",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CaseTypeOfWork_TypeOfWork_WorkDoneDescriptionListId",
                table: "CaseTypeOfWork");

            migrationBuilder.RenameColumn(
                name: "WorkDoneDescriptionListId",
                table: "CaseTypeOfWork",
                newName: "WorkDoneListId");

            migrationBuilder.RenameIndex(
                name: "IX_CaseTypeOfWork_WorkDoneDescriptionListId",
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
    }
}
