using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Defult.Migrations
{
    public partial class edituser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Diseases_DiseaseId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_DiseaseId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CompletedWorkoutsCounter",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DiseaseId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Users");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompletedWorkoutsCounter",
                table: "Users",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DiseaseId",
                table: "Users",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Gender",
                table: "Users",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Users_DiseaseId",
                table: "Users",
                column: "DiseaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Diseases_DiseaseId",
                table: "Users",
                column: "DiseaseId",
                principalTable: "Diseases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
