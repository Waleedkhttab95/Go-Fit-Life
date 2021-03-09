using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Defult.Migrations
{
    public partial class addingBodyPartSection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BodyPartSection",
                columns: table => new
                {
                    BPartId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BPartName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BodyPartSection", x => x.BPartId);
                });

            migrationBuilder.CreateTable(
                name: "ExcerciseBPart",
                columns: table => new
                {
                    ExcerBodyPart = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EBP_BPartId = table.Column<int>(nullable: false),
                    EBP_ExId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExcerciseBPart", x => x.ExcerBodyPart);

                   table.ForeignKey(
                    name: "FK_ExcerciseBodyPart_BodyPartSection_BPartId",
                     column: x => x.EBP_BPartId,
                     principalTable: "BodyPartSection",
                     principalColumn: "BPartId",
                      onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExcerciseBPart_Excercises_ExId",
                        column: x => x.EBP_ExId,
                        principalTable: "Excercises",
                        principalColumn: "ExId",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BodyPartSection");

            migrationBuilder.DropTable(
                name: "ExcerciseBPart");
        }
    }
}
