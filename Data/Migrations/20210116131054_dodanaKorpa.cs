using Microsoft.EntityFrameworkCore.Migrations;

namespace eKorpa.Migrations
{
    public partial class dodanaKorpa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kupac");

            migrationBuilder.DropTable(
                name: "Prodavac");

            migrationBuilder.CreateTable(
                name: "Korpa",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KupacID = table.Column<string>(nullable: true),
                    ArtikalID = table.Column<int>(nullable: false),
                    kolicina = table.Column<int>(nullable: false),
                    cijena = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korpa", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Korpa");

            migrationBuilder.CreateTable(
                name: "Kupac",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KorisnikID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kupac", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Kupac_AspNetUsers_KorisnikID",
                        column: x => x.KorisnikID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Prodavac",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KorisnikID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    isRadnja = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prodavac", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Prodavac_AspNetUsers_KorisnikID",
                        column: x => x.KorisnikID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Kupac_KorisnikID",
                table: "Kupac",
                column: "KorisnikID",
                unique: true,
                filter: "[KorisnikID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Prodavac_KorisnikID",
                table: "Prodavac",
                column: "KorisnikID",
                unique: true,
                filter: "[KorisnikID] IS NOT NULL");
        }
    }
}
