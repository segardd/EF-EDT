using Microsoft.EntityFrameworkCore.Migrations;

namespace Universite.Data.Migrations
{
    public partial class AddSalle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SalleID",
                table: "UE",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "salle",
                table: "Cours",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LSalleSalleID",
                table: "Cours",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Salle",
                columns: table => new
                {
                    SalleID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nomSAlle = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salle", x => x.SalleID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UE_SalleID",
                table: "UE",
                column: "SalleID");

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

            migrationBuilder.AddForeignKey(
                name: "FK_UE_Salle_SalleID",
                table: "UE",
                column: "SalleID",
                principalTable: "Salle",
                principalColumn: "SalleID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cours_Salle_LSalleSalleID",
                table: "Cours");

            migrationBuilder.DropForeignKey(
                name: "FK_UE_Salle_SalleID",
                table: "UE");

            migrationBuilder.DropTable(
                name: "Salle");

            migrationBuilder.DropIndex(
                name: "IX_UE_SalleID",
                table: "UE");

            migrationBuilder.DropIndex(
                name: "IX_Cours_LSalleSalleID",
                table: "Cours");

            migrationBuilder.DropColumn(
                name: "SalleID",
                table: "UE");

            migrationBuilder.DropColumn(
                name: "LSalleSalleID",
                table: "Cours");

            migrationBuilder.AlterColumn<string>(
                name: "salle",
                table: "Cours",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
