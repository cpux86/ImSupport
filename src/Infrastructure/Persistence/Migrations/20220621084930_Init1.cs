using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class Init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cases_WorksList_WorksListId",
                table: "Cases");

            migrationBuilder.DropIndex(
                name: "IX_Cases_WorksListId",
                table: "Cases");

            migrationBuilder.DropColumn(
                name: "WorksListId",
                table: "Cases");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WorksListId",
                table: "Cases",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cases_WorksListId",
                table: "Cases",
                column: "WorksListId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cases_WorksList_WorksListId",
                table: "Cases",
                column: "WorksListId",
                principalTable: "WorksList",
                principalColumn: "Id");
        }
    }
}
