using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class Init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cases_CaseDescriptions_DescriptionId",
                table: "Cases");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CaseDescriptions",
                table: "CaseDescriptions");

            migrationBuilder.RenameTable(
                name: "CaseDescriptions",
                newName: "CaseDescription");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CaseDescription",
                table: "CaseDescription",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cases_CaseDescription_DescriptionId",
                table: "Cases",
                column: "DescriptionId",
                principalTable: "CaseDescription",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cases_CaseDescription_DescriptionId",
                table: "Cases");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CaseDescription",
                table: "CaseDescription");

            migrationBuilder.RenameTable(
                name: "CaseDescription",
                newName: "CaseDescriptions");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CaseDescriptions",
                table: "CaseDescriptions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cases_CaseDescriptions_DescriptionId",
                table: "Cases",
                column: "DescriptionId",
                principalTable: "CaseDescriptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
