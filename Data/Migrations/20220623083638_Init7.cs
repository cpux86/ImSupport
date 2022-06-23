using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class Init7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cases_Offices_OfficeId",
                table: "Cases");

            migrationBuilder.RenameColumn(
                name: "OfficeId",
                table: "Cases",
                newName: "ClientOfficeId");

            migrationBuilder.RenameIndex(
                name: "IX_Cases_OfficeId",
                table: "Cases",
                newName: "IX_Cases_ClientOfficeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cases_Offices_ClientOfficeId",
                table: "Cases",
                column: "ClientOfficeId",
                principalTable: "Offices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cases_Offices_ClientOfficeId",
                table: "Cases");

            migrationBuilder.RenameColumn(
                name: "ClientOfficeId",
                table: "Cases",
                newName: "OfficeId");

            migrationBuilder.RenameIndex(
                name: "IX_Cases_ClientOfficeId",
                table: "Cases",
                newName: "IX_Cases_OfficeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cases_Offices_OfficeId",
                table: "Cases",
                column: "OfficeId",
                principalTable: "Offices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
