using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class Init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CaseNumber",
                table: "Cases");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Cases",
                newName: "CaseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CaseId",
                table: "Cases",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "CaseNumber",
                table: "Cases",
                type: "INTEGER",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 1);
        }
    }
}
