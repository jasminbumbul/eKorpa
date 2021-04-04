using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eKorpa.Migrations
{
    public partial class zavrseniartikalirejting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rejting",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Opis = table.Column<string>(nullable: true),
                    Ocjena = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rejting", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ZavrseniArtikal",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArtikalID = table.Column<int>(nullable: false),
                    ProdavacID = table.Column<string>(nullable: true),
                    KupacID = table.Column<string>(nullable: true),
                    Datum = table.Column<DateTime>(nullable: false),
                    Kolicina = table.Column<int>(nullable: false),
                    RejtingID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZavrseniArtikal", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ZavrseniArtikal_Artikal_ArtikalID",
                        column: x => x.ArtikalID,
                        principalTable: "Artikal",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ZavrseniArtikal_AspNetUsers_KupacID",
                        column: x => x.KupacID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ZavrseniArtikal_AspNetUsers_ProdavacID",
                        column: x => x.ProdavacID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ZavrseniArtikal_Rejting_RejtingID",
                        column: x => x.RejtingID,
                        principalTable: "Rejting",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ZavrseniArtikal_ArtikalID",
                table: "ZavrseniArtikal",
                column: "ArtikalID");

            migrationBuilder.CreateIndex(
                name: "IX_ZavrseniArtikal_KupacID",
                table: "ZavrseniArtikal",
                column: "KupacID");

            migrationBuilder.CreateIndex(
                name: "IX_ZavrseniArtikal_ProdavacID",
                table: "ZavrseniArtikal",
                column: "ProdavacID");

            migrationBuilder.CreateIndex(
                name: "IX_ZavrseniArtikal_RejtingID",
                table: "ZavrseniArtikal",
                column: "RejtingID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ZavrseniArtikal");

            migrationBuilder.DropTable(
                name: "Rejting");
        }
    }
}
