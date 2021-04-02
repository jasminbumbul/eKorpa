using Microsoft.EntityFrameworkCore.Migrations;

namespace eKorpa.Migrations
{
    public partial class dodanaAdresa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Adresa",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Adresa",
                table: "AspNetUsers");
        }
    }
}
