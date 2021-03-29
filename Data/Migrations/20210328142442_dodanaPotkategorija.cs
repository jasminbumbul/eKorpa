using Microsoft.EntityFrameworkCore.Migrations;

namespace eKorpa.Migrations
{
    public partial class dodanaPotkategorija : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PotkategorijaID",
                table: "Artikal",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Potkategorija",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Potkategorija", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Artikal_PotkategorijaID",
                table: "Artikal",
                column: "PotkategorijaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Artikal_Potkategorija_PotkategorijaID",
                table: "Artikal",
                column: "PotkategorijaID",
                principalTable: "Potkategorija",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artikal_Potkategorija_PotkategorijaID",
                table: "Artikal");

            migrationBuilder.DropTable(
                name: "Potkategorija");

            migrationBuilder.DropIndex(
                name: "IX_Artikal_PotkategorijaID",
                table: "Artikal");

            migrationBuilder.DropColumn(
                name: "PotkategorijaID",
                table: "Artikal");
        }
    }
}
