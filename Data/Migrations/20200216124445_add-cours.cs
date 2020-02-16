using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Universite.Data.Migrations
{
    public partial class addcours : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cours",
                columns: table => new
                {
                    CoursID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    salle = table.Column<string>(nullable: true),
                    DHDebut = table.Column<DateTime>(nullable: false),
                    DHFin = table.Column<DateTime>(nullable: false),
                    UEID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cours", x => x.CoursID);
                    table.ForeignKey(
                        name: "FK_Cours_UE_UEID",
                        column: x => x.UEID,
                        principalTable: "UE",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cours_UEID",
                table: "Cours",
                column: "UEID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cours");
        }
    }
}
