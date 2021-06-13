using Microsoft.EntityFrameworkCore.Migrations;

namespace eKorpa.Migrations
{
    public partial class dodanaSlikaUZavrseniArtikal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SlikaID",
                table: "ZavrseniArtikal",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ZavrseniArtikal_SlikaID",
                table: "ZavrseniArtikal",
                column: "SlikaID");

            migrationBuilder.AddForeignKey(
                name: "FK_ZavrseniArtikal_Slika_SlikaID",
                table: "ZavrseniArtikal",
                column: "SlikaID",
                principalTable: "Slika",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ZavrseniArtikal_Slika_SlikaID",
                table: "ZavrseniArtikal");

            migrationBuilder.DropIndex(
                name: "IX_ZavrseniArtikal_SlikaID",
                table: "ZavrseniArtikal");

            migrationBuilder.DropColumn(
                name: "SlikaID",
                table: "ZavrseniArtikal");
        }
    }
}
