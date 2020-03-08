using Microsoft.EntityFrameworkCore.Migrations;

namespace Universite.Data.Migrations
{
    public partial class updateEnseignant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Enseignant",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Enseignant");
        }
    }
}
