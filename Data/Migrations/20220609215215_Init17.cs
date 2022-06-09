﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class Init17 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CaseTypeOfWork_TypeOfWork_TypeOfWorksId",
                table: "CaseTypeOfWork");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TypeOfWork",
                table: "TypeOfWork");

            migrationBuilder.RenameTable(
                name: "TypeOfWork",
                newName: "TypeOfWorks");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TypeOfWorks",
                table: "TypeOfWorks",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CaseTypeOfWork_TypeOfWorks_TypeOfWorksId",
                table: "CaseTypeOfWork",
                column: "TypeOfWorksId",
                principalTable: "TypeOfWorks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CaseTypeOfWork_TypeOfWorks_TypeOfWorksId",
                table: "CaseTypeOfWork");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TypeOfWorks",
                table: "TypeOfWorks");

            migrationBuilder.RenameTable(
                name: "TypeOfWorks",
                newName: "TypeOfWork");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TypeOfWork",
                table: "TypeOfWork",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CaseTypeOfWork_TypeOfWork_TypeOfWorksId",
                table: "CaseTypeOfWork",
                column: "TypeOfWorksId",
                principalTable: "TypeOfWork",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}