using Microsoft.EntityFrameworkCore.Migrations;

namespace eKorpa.Migrations
{
    public partial class fixPovezaneTabele : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "KupacID",
                table: "ListaZelja",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "KupacID",
                table: "Korpa",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Slika_ArtikalID",
                table: "Slika",
                column: "ArtikalID");

            migrationBuilder.CreateIndex(
                name: "IX_ListaZelja_ArtikalID",
                table: "ListaZelja",
                column: "ArtikalID");

            migrationBuilder.CreateIndex(
                name: "IX_ListaZelja_KupacID",
                table: "ListaZelja",
                column: "KupacID");

            migrationBuilder.CreateIndex(
                name: "IX_Korpa_ArtikalID",
                table: "Korpa",
                column: "ArtikalID");

            migrationBuilder.CreateIndex(
                name: "IX_Korpa_KupacID",
                table: "Korpa",
                column: "KupacID");

            migrationBuilder.AddForeignKey(
                name: "FK_Korpa_Artikal_ArtikalID",
                table: "Korpa",
                column: "ArtikalID",
                principalTable: "Artikal",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Korpa_AspNetUsers_KupacID",
                table: "Korpa",
                column: "KupacID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ListaZelja_Artikal_ArtikalID",
                table: "ListaZelja",
                column: "ArtikalID",
                principalTable: "Artikal",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ListaZelja_AspNetUsers_KupacID",
                table: "ListaZelja",
                column: "KupacID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Slika_Artikal_ArtikalID",
                table: "Slika",
                column: "ArtikalID",
                principalTable: "Artikal",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Korpa_Artikal_ArtikalID",
                table: "Korpa");

            migrationBuilder.DropForeignKey(
                name: "FK_Korpa_AspNetUsers_KupacID",
                table: "Korpa");

            migrationBuilder.DropForeignKey(
                name: "FK_ListaZelja_Artikal_ArtikalID",
                table: "ListaZelja");

            migrationBuilder.DropForeignKey(
                name: "FK_ListaZelja_AspNetUsers_KupacID",
                table: "ListaZelja");

            migrationBuilder.DropForeignKey(
                name: "FK_Slika_Artikal_ArtikalID",
                table: "Slika");

            migrationBuilder.DropIndex(
                name: "IX_Slika_ArtikalID",
                table: "Slika");

            migrationBuilder.DropIndex(
                name: "IX_ListaZelja_ArtikalID",
                table: "ListaZelja");

            migrationBuilder.DropIndex(
                name: "IX_ListaZelja_KupacID",
                table: "ListaZelja");

            migrationBuilder.DropIndex(
                name: "IX_Korpa_ArtikalID",
                table: "Korpa");

            migrationBuilder.DropIndex(
                name: "IX_Korpa_KupacID",
                table: "Korpa");

            migrationBuilder.AlterColumn<string>(
                name: "KupacID",
                table: "ListaZelja",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "KupacID",
                table: "Korpa",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
