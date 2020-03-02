using Microsoft.EntityFrameworkCore.Migrations;

namespace Universite.Data.Migrations
{
    public partial class updateCours : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "titre",
                table: "Cours",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "titre",
                table: "Cours");
        }
    }
}
