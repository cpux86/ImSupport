using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class Init14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CaseTypeOfWork_TypeOfWork_WorkDoneDescriptionListId",
                table: "CaseTypeOfWork");

            migrationBuilder.RenameColumn(
                name: "WorkDoneDescriptionListId",
                table: "CaseTypeOfWork",
                newName: "TypeOfWorksId");

            migrationBuilder.RenameIndex(
                name: "IX_CaseTypeOfWork_WorkDoneDescriptionListId",
                table: "CaseTypeOfWork",
                newName: "IX_CaseTypeOfWork_TypeOfWorksId");

            migrationBuilder.AddForeignKey(
                name: "FK_CaseTypeOfWork_TypeOfWork_TypeOfWorksId",
                table: "CaseTypeOfWork",
                column: "TypeOfWorksId",
                principalTable: "TypeOfWork",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CaseTypeOfWork_TypeOfWork_TypeOfWorksId",
                table: "CaseTypeOfWork");

            migrationBuilder.RenameColumn(
                name: "TypeOfWorksId",
                table: "CaseTypeOfWork",
                newName: "WorkDoneDescriptionListId");

            migrationBuilder.RenameIndex(
                name: "IX_CaseTypeOfWork_TypeOfWorksId",
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
    }
}
