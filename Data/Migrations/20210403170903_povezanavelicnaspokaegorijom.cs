using Microsoft.EntityFrameworkCore.Migrations;

namespace eKorpa.Migrations
{
    public partial class povezanavelicnaspokaegorijom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PotkategorijaID",
                table: "Velicina",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Velicina_PotkategorijaID",
                table: "Velicina",
                column: "PotkategorijaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Velicina_Potkategorija_PotkategorijaID",
                table: "Velicina",
                column: "PotkategorijaID",
                principalTable: "Potkategorija",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Velicina_Potkategorija_PotkategorijaID",
                table: "Velicina");

            migrationBuilder.DropIndex(
                name: "IX_Velicina_PotkategorijaID",
                table: "Velicina");

            migrationBuilder.DropColumn(
                name: "PotkategorijaID",
                table: "Velicina");
        }
    }
}
