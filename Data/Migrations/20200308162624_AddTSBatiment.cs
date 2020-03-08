using Microsoft.EntityFrameworkCore.Migrations;

namespace Universite.Data.Migrations
{
    public partial class AddTSBatiment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BatimentID",
                table: "Salle",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TypeCoursID",
                table: "Cours",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Batiment",
                columns: table => new
                {
                    BatimentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomBatiment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Batiment", x => x.BatimentID);
                });

            migrationBuilder.CreateTable(
                name: "TypeCours",
                columns: table => new
                {
                    TypeCoursID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Intitule = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeCours", x => x.TypeCoursID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Salle_BatimentID",
                table: "Salle",
                column: "BatimentID");

            migrationBuilder.CreateIndex(
                name: "IX_Cours_TypeCoursID",
                table: "Cours",
                column: "TypeCoursID");

            migrationBuilder.AddForeignKey(
                name: "FK_Cours_TypeCours_TypeCoursID",
                table: "Cours",
                column: "TypeCoursID",
                principalTable: "TypeCours",
                principalColumn: "TypeCoursID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Salle_Batiment_BatimentID",
                table: "Salle",
                column: "BatimentID",
                principalTable: "Batiment",
                principalColumn: "BatimentID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cours_TypeCours_TypeCoursID",
                table: "Cours");

            migrationBuilder.DropForeignKey(
                name: "FK_Salle_Batiment_BatimentID",
                table: "Salle");

            migrationBuilder.DropTable(
                name: "Batiment");

            migrationBuilder.DropTable(
                name: "TypeCours");

            migrationBuilder.DropIndex(
                name: "IX_Salle_BatimentID",
                table: "Salle");

            migrationBuilder.DropIndex(
                name: "IX_Cours_TypeCoursID",
                table: "Cours");

            migrationBuilder.DropColumn(
                name: "BatimentID",
                table: "Salle");

            migrationBuilder.DropColumn(
                name: "TypeCoursID",
                table: "Cours");
        }
    }
}
