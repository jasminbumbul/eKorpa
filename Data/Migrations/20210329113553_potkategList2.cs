using Microsoft.EntityFrameworkCore.Migrations;

namespace eKorpa.Migrations
{
    public partial class potkategList2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kategorija_Potkategorija_PotkategorijaID",
                table: "Kategorija");

            migrationBuilder.DropIndex(
                name: "IX_Kategorija_PotkategorijaID",
                table: "Kategorija");

            migrationBuilder.DropColumn(
                name: "PotkategorijaID",
                table: "Kategorija");

            migrationBuilder.AddColumn<int>(
                name: "KategorijaID",
                table: "Potkategorija",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Potkategorija_KategorijaID",
                table: "Potkategorija",
                column: "KategorijaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Potkategorija_Kategorija_KategorijaID",
                table: "Potkategorija",
                column: "KategorijaID",
                principalTable: "Kategorija",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Potkategorija_Kategorija_KategorijaID",
                table: "Potkategorija");

            migrationBuilder.DropIndex(
                name: "IX_Potkategorija_KategorijaID",
                table: "Potkategorija");

            migrationBuilder.DropColumn(
                name: "KategorijaID",
                table: "Potkategorija");

            migrationBuilder.AddColumn<int>(
                name: "PotkategorijaID",
                table: "Kategorija",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Kategorija_PotkategorijaID",
                table: "Kategorija",
                column: "PotkategorijaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Kategorija_Potkategorija_PotkategorijaID",
                table: "Kategorija",
                column: "PotkategorijaID",
                principalTable: "Potkategorija",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
