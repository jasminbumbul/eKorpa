using Microsoft.EntityFrameworkCore.Migrations;

namespace eKorpa.Migrations
{
    public partial class ponuda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "CijenaSaPopustom",
                table: "Artikal",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.CreateTable(
                name: "Ponuda",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Opis = table.Column<string>(nullable: true),
                    ProcenatSnizenja = table.Column<float>(nullable: false),
                    KategorijaID = table.Column<int>(nullable: false),
                    PotkategorijaID = table.Column<int>(nullable: false),
                    IsAktivna = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ponuda", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Ponuda_Kategorija_KategorijaID",
                        column: x => x.KategorijaID,
                        principalTable: "Kategorija",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ponuda_Potkategorija_PotkategorijaID",
                        column: x => x.PotkategorijaID,
                        principalTable: "Potkategorija",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ponuda_KategorijaID",
                table: "Ponuda",
                column: "KategorijaID");

            migrationBuilder.CreateIndex(
                name: "IX_Ponuda_PotkategorijaID",
                table: "Ponuda",
                column: "PotkategorijaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ponuda");

            migrationBuilder.DropColumn(
                name: "CijenaSaPopustom",
                table: "Artikal");
        }
    }
}
