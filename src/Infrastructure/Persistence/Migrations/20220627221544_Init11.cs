using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class Init11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Company_CompanyId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Offices_Company_CompanyId",
                table: "Offices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Company",
                table: "Company");

            migrationBuilder.RenameTable(
                name: "Company",
                newName: "Companys");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Offices",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Companys",
                table: "Companys",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Companys_CompanyId",
                table: "Employees",
                column: "CompanyId",
                principalTable: "Companys",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Offices_Companys_CompanyId",
                table: "Offices",
                column: "CompanyId",
                principalTable: "Companys",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Companys_CompanyId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Offices_Companys_CompanyId",
                table: "Offices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Companys",
                table: "Companys");

            migrationBuilder.RenameTable(
                name: "Companys",
                newName: "Company");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Offices",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Company",
                table: "Company",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Company_CompanyId",
                table: "Employees",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Offices_Company_CompanyId",
                table: "Offices",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id");
        }
    }
}
