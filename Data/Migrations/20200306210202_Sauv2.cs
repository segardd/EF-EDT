using Microsoft.EntityFrameworkCore.Migrations;

namespace Universite.Data.Migrations
{
    public partial class Sauv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cours_Salle_LSalleSalleID",
                table: "Cours");

            migrationBuilder.DropIndex(
                name: "IX_Cours_LSalleSalleID",
                table: "Cours");

            migrationBuilder.DropColumn(
                name: "LSalleSalleID",
                table: "Cours");

            migrationBuilder.DropColumn(
                name: "salle",
                table: "Cours");

            migrationBuilder.AddColumn<int>(
                name: "SalleID",
                table: "Cours",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cours_SalleID",
                table: "Cours",
                column: "SalleID");

            migrationBuilder.AddForeignKey(
                name: "FK_Cours_Salle_SalleID",
                table: "Cours",
                column: "SalleID",
                principalTable: "Salle",
                principalColumn: "SalleID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cours_Salle_SalleID",
                table: "Cours");

            migrationBuilder.DropIndex(
                name: "IX_Cours_SalleID",
                table: "Cours");

            migrationBuilder.DropColumn(
                name: "SalleID",
                table: "Cours");

            migrationBuilder.AddColumn<int>(
                name: "LSalleSalleID",
                table: "Cours",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "salle",
                table: "Cours",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cours_LSalleSalleID",
                table: "Cours",
                column: "LSalleSalleID");

            migrationBuilder.AddForeignKey(
                name: "FK_Cours_Salle_LSalleSalleID",
                table: "Cours",
                column: "LSalleSalleID",
                principalTable: "Salle",
                principalColumn: "SalleID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
