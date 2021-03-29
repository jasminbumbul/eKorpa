using Microsoft.EntityFrameworkCore.Migrations;

namespace eKorpa.Migrations
{
    public partial class potkategList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PotkategorijaID",
                table: "Kategorija",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
