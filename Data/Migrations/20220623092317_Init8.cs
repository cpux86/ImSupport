using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class Init8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ServiceCenter",
                table: "Cases");

            migrationBuilder.AddColumn<int>(
                name: "ServiceId",
                table: "Cases",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Cases_ServiceId",
                table: "Cases",
                column: "ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cases_Offices_ServiceId",
                table: "Cases",
                column: "ServiceId",
                principalTable: "Offices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cases_Offices_ServiceId",
                table: "Cases");

            migrationBuilder.DropIndex(
                name: "IX_Cases_ServiceId",
                table: "Cases");

            migrationBuilder.DropColumn(
                name: "ServiceId",
                table: "Cases");

            migrationBuilder.AddColumn<string>(
                name: "ServiceCenter",
                table: "Cases",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
