using Microsoft.EntityFrameworkCore.Migrations;

namespace eKorpa.Migrations
{
    public partial class KategorijaFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Artikal_KategorijaID",
                table: "Artikal",
                column: "KategorijaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Artikal_Kategorija_KategorijaID",
                table: "Artikal",
                column: "KategorijaID",
                principalTable: "Kategorija",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artikal_Kategorija_KategorijaID",
                table: "Artikal");

            migrationBuilder.DropIndex(
                name: "IX_Artikal_KategorijaID",
                table: "Artikal");
        }
    }
}
