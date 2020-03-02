using Microsoft.EntityFrameworkCore.Migrations;

namespace Universite.Data.Migrations
{
    public partial class UpdateCours2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "titre",
                table: "Cours");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "titre",
                table: "Cours",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
