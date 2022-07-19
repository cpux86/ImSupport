using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class Init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Employees_DirectorId",
                table: "Departments");

            migrationBuilder.RenameColumn(
                name: "DirectorId",
                table: "Departments",
                newName: "HeadOfDepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Departments_DirectorId",
                table: "Departments",
                newName: "IX_Departments_HeadOfDepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Employees_HeadOfDepartmentId",
                table: "Departments",
                column: "HeadOfDepartmentId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Employees_HeadOfDepartmentId",
                table: "Departments");

            migrationBuilder.RenameColumn(
                name: "HeadOfDepartmentId",
                table: "Departments",
                newName: "DirectorId");

            migrationBuilder.RenameIndex(
                name: "IX_Departments_HeadOfDepartmentId",
                table: "Departments",
                newName: "IX_Departments_DirectorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Employees_DirectorId",
                table: "Departments",
                column: "DirectorId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
