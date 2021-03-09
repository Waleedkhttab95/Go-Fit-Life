using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Defult.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Diseases",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DiseaseName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diseases", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Excercises",
                columns: table => new
                {
                    ExId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ExBodyPart = table.Column<string>(nullable: true),
                    ExDesc = table.Column<string>(nullable: true),
                    ExDuration = table.Column<string>(nullable: true),
                    ExEquip = table.Column<string>(nullable: true),
                    ExName = table.Column<string>(nullable: true),
                    ExSkill = table.Column<string>(nullable: true),
                    ExStepOne = table.Column<string>(nullable: true),
                    ExStepTwo = table.Column<string>(nullable: true),
                    ExType = table.Column<string>(nullable: true),
                    ExVideo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Excercises", x => x.ExId);
                });

            migrationBuilder.CreateTable(
                name: "Foods",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Fcalore = table.Column<double>(nullable: false),
                    Fcarb = table.Column<double>(nullable: false),
                    Ffat = table.Column<double>(nullable: false),
                    Foodname = table.Column<string>(nullable: true),
                    Fproten = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Program_Workout",
                columns: table => new
                {
                    PW_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PW_PId = table.Column<int>(nullable: false),
                    PW_WId = table.Column<int>(nullable: false),
                    P_Day = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Program_Workout", x => x.PW_Id);
                });

            migrationBuilder.CreateTable(
                name: "Programs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    P_Area = table.Column<string>(nullable: true),
                    P_Level = table.Column<string>(nullable: true),
                    P_Type = table.Column<string>(nullable: true),
                    P_name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Programs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Workout",
                columns: table => new
                {
                    Wid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    WArea = table.Column<string>(nullable: true),
                    WLevel = table.Column<string>(nullable: true),
                    WName = table.Column<string>(nullable: true),
                    WType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workout", x => x.Wid);
                });

            migrationBuilder.CreateTable(
                name: "Workout_Excercise",
                columns: table => new
                {
                    WE_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    WE_ExId = table.Column<int>(nullable: false),
                    WE_WId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workout_Excercise", x => x.WE_id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Age = table.Column<int>(nullable: false),
                    Calories = table.Column<int>(nullable: false),
                    Carb = table.Column<int>(nullable: false),
                    DiseaseId = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Fat = table.Column<int>(nullable: false),
                    Gender = table.Column<bool>(nullable: false),
                    GoalWieght = table.Column<int>(nullable: false),
                    Height = table.Column<float>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Password = table.Column<int>(nullable: false),
                    ProgramsId = table.Column<int>(nullable: false),
                    Protin = table.Column<int>(nullable: false),
                    Repassword = table.Column<int>(nullable: false),
                    Startdate = table.Column<DateTime>(nullable: false),
                    Weight = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Diseases_DiseaseId",
                        column: x => x.DiseaseId,
                        principalTable: "Diseases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Programs_ProgramsId",
                        column: x => x.ProgramsId,
                        principalTable: "Programs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_DiseaseId",
                table: "Users",
                column: "DiseaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ProgramsId",
                table: "Users",
                column: "ProgramsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Excercises");

            migrationBuilder.DropTable(
                name: "Foods");

            migrationBuilder.DropTable(
                name: "Program_Workout");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Workout");

            migrationBuilder.DropTable(
                name: "Workout_Excercise");

            migrationBuilder.DropTable(
                name: "Diseases");

            migrationBuilder.DropTable(
                name: "Programs");
        }
    }
}
