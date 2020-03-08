using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Universite.Data.Migrations
{
    public partial class reBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Enseignant",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(nullable: false),
                    Prenom = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enseignant", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Formation",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IntituleDiplome = table.Column<string>(nullable: false),
                    AnneeDiplome = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Formation", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Salle",
                columns: table => new
                {
                    SalleID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomSalle = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salle", x => x.SalleID);
                });

            migrationBuilder.CreateTable(
                name: "Etudiant",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(nullable: false),
                    Prenom = table.Column<string>(nullable: false),
                    Naissance = table.Column<DateTime>(nullable: false),
                    Genre = table.Column<int>(nullable: false),
                    FormationID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etudiant", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Etudiant_Formation_FormationID",
                        column: x => x.FormationID,
                        principalTable: "Formation",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UE",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero = table.Column<string>(nullable: false),
                    Intitule = table.Column<string>(nullable: false),
                    FormationID = table.Column<int>(nullable: false),
                    SalleID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UE", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UE_Formation_FormationID",
                        column: x => x.FormationID,
                        principalTable: "Formation",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UE_Salle_SalleID",
                        column: x => x.SalleID,
                        principalTable: "Salle",
                        principalColumn: "SalleID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Enseigne",
                columns: table => new
                {
                    EnseigneID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnseignantID = table.Column<int>(nullable: true),
                    UEID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enseigne", x => x.EnseigneID);
                    table.ForeignKey(
                        name: "FK_Enseigne_Enseignant_EnseignantID",
                        column: x => x.EnseignantID,
                        principalTable: "Enseignant",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Enseigne_UE_UEID",
                        column: x => x.UEID,
                        principalTable: "UE",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Groupe",
                columns: table => new
                {
                    GroupeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomGroupe = table.Column<string>(nullable: true),
                    UEID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groupe", x => x.GroupeID);
                    table.ForeignKey(
                        name: "FK_Groupe_UE_UEID",
                        column: x => x.UEID,
                        principalTable: "UE",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Note",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Valeur = table.Column<float>(nullable: false),
                    UEID = table.Column<int>(nullable: true),
                    EtudiantID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Note", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Note_Etudiant_EtudiantID",
                        column: x => x.EtudiantID,
                        principalTable: "Etudiant",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Note_UE_UEID",
                        column: x => x.UEID,
                        principalTable: "UE",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cours",
                columns: table => new
                {
                    CoursID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DHDebut = table.Column<DateTime>(nullable: false),
                    DHFin = table.Column<DateTime>(nullable: false),
                    EnseigneID = table.Column<int>(nullable: true),
                    SalleID = table.Column<int>(nullable: true),
                    GroupeID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cours", x => x.CoursID);
                    table.ForeignKey(
                        name: "FK_Cours_Enseigne_EnseigneID",
                        column: x => x.EnseigneID,
                        principalTable: "Enseigne",
                        principalColumn: "EnseigneID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cours_Groupe_GroupeID",
                        column: x => x.GroupeID,
                        principalTable: "Groupe",
                        principalColumn: "GroupeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cours_Salle_SalleID",
                        column: x => x.SalleID,
                        principalTable: "Salle",
                        principalColumn: "SalleID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cours_EnseigneID",
                table: "Cours",
                column: "EnseigneID");

            migrationBuilder.CreateIndex(
                name: "IX_Cours_GroupeID",
                table: "Cours",
                column: "GroupeID");

            migrationBuilder.CreateIndex(
                name: "IX_Cours_SalleID",
                table: "Cours",
                column: "SalleID");

            migrationBuilder.CreateIndex(
                name: "IX_Enseigne_EnseignantID",
                table: "Enseigne",
                column: "EnseignantID");

            migrationBuilder.CreateIndex(
                name: "IX_Enseigne_UEID",
                table: "Enseigne",
                column: "UEID");

            migrationBuilder.CreateIndex(
                name: "IX_Etudiant_FormationID",
                table: "Etudiant",
                column: "FormationID");

            migrationBuilder.CreateIndex(
                name: "IX_Groupe_UEID",
                table: "Groupe",
                column: "UEID");

            migrationBuilder.CreateIndex(
                name: "IX_Note_EtudiantID",
                table: "Note",
                column: "EtudiantID");

            migrationBuilder.CreateIndex(
                name: "IX_Note_UEID",
                table: "Note",
                column: "UEID");

            migrationBuilder.CreateIndex(
                name: "IX_UE_FormationID",
                table: "UE",
                column: "FormationID");

            migrationBuilder.CreateIndex(
                name: "IX_UE_SalleID",
                table: "UE",
                column: "SalleID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cours");

            migrationBuilder.DropTable(
                name: "Note");

            migrationBuilder.DropTable(
                name: "Enseigne");

            migrationBuilder.DropTable(
                name: "Groupe");

            migrationBuilder.DropTable(
                name: "Etudiant");

            migrationBuilder.DropTable(
                name: "Enseignant");

            migrationBuilder.DropTable(
                name: "UE");

            migrationBuilder.DropTable(
                name: "Formation");

            migrationBuilder.DropTable(
                name: "Salle");
        }
    }
}
