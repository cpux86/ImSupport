using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class Init6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cases_Locations_LocationId",
                table: "Cases");

            migrationBuilder.DropForeignKey(
                name: "FK_Devices_Locations_LocationId",
                table: "Devices");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.RenameColumn(
                name: "LocationId",
                table: "Devices",
                newName: "OfficeId");

            migrationBuilder.RenameIndex(
                name: "IX_Devices_LocationId",
                table: "Devices",
                newName: "IX_Devices_OfficeId");

            migrationBuilder.RenameColumn(
                name: "LocationId",
                table: "Cases",
                newName: "OfficeId");

            migrationBuilder.RenameIndex(
                name: "IX_Cases_LocationId",
                table: "Cases",
                newName: "IX_Cases_OfficeId");

            migrationBuilder.AddColumn<string>(
                name: "ServiceCenter",
                table: "Cases",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Offices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    CompanyId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Offices_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Surname = table.Column<string>(type: "TEXT", nullable: false),
                    Phone = table.Column<string>(type: "TEXT", nullable: false),
                    WorkPhone = table.Column<string>(type: "TEXT", nullable: false),
                    CompanyId = table.Column<int>(type: "INTEGER", nullable: false),
                    OfficeId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employee_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employee_Offices_OfficeId",
                        column: x => x.OfficeId,
                        principalTable: "Offices",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employee_CompanyId",
                table: "Employee",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_OfficeId",
                table: "Employee",
                column: "OfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_Offices_CompanyId",
                table: "Offices",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cases_Offices_OfficeId",
                table: "Cases",
                column: "OfficeId",
                principalTable: "Offices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Devices_Offices_OfficeId",
                table: "Devices",
                column: "OfficeId",
                principalTable: "Offices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cases_Offices_OfficeId",
                table: "Cases");

            migrationBuilder.DropForeignKey(
                name: "FK_Devices_Offices_OfficeId",
                table: "Devices");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Offices");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropColumn(
                name: "ServiceCenter",
                table: "Cases");

            migrationBuilder.RenameColumn(
                name: "OfficeId",
                table: "Devices",
                newName: "LocationId");

            migrationBuilder.RenameIndex(
                name: "IX_Devices_OfficeId",
                table: "Devices",
                newName: "IX_Devices_LocationId");

            migrationBuilder.RenameColumn(
                name: "OfficeId",
                table: "Cases",
                newName: "LocationId");

            migrationBuilder.RenameIndex(
                name: "IX_Cases_OfficeId",
                table: "Cases",
                newName: "IX_Cases_LocationId");

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Cases_Locations_LocationId",
                table: "Cases",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Devices_Locations_LocationId",
                table: "Devices",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
