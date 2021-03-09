using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Defult.Migrations
{
    public partial class editnameimg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Startdate",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "profileImg",
                table: "Users",
                newName: "imgPath");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "imgPath",
                table: "Users",
                newName: "profileImg");

            migrationBuilder.AddColumn<DateTime>(
                name: "Startdate",
                table: "Users",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
