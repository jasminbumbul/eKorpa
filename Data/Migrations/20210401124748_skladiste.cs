using Microsoft.EntityFrameworkCore.Migrations;

namespace eKorpa.Migrations
{
    public partial class skladiste : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BrojUSkladistu",
                table: "Artikal",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BrojUSkladistu",
                table: "Artikal");
        }
    }
}
