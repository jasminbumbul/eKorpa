using Microsoft.EntityFrameworkCore.Migrations;

namespace eKorpa.Migrations
{
    public partial class updatevelicina : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VelicinaBroj",
                table: "Velicina");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VelicinaBroj",
                table: "Velicina",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
