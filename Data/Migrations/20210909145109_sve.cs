using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class sve : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Boja",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boja", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Brend",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brend", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Grad",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grad", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Kategorija",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazivKategorije = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategorija", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Materijal",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materijal", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Poruka",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImePrezime = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Predmet = table.Column<string>(nullable: true),
                    Sadrzaj = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Poruka", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Rejting",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DojamKupca = table.Column<string>(nullable: true),
                    DojamProdavaca = table.Column<string>(nullable: true),
                    KupacOstavioDojam = table.Column<bool>(nullable: false),
                    ProdavacOstavioDojam = table.Column<bool>(nullable: false),
                    OcjenaKupca = table.Column<float>(nullable: false),
                    OcjenaProdavaca = table.Column<float>(nullable: false),
                    DatumProdavac = table.Column<DateTime>(nullable: false),
                    DatumKupac = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rejting", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Adresa",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OpcinaID = table.Column<int>(nullable: true),
                    MjestoStanovanja = table.Column<string>(nullable: true),
                    PostanskiBroj = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adresa", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Adresa_Grad_OpcinaID",
                        column: x => x.OpcinaID,
                        principalTable: "Grad",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Potkategorija",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true),
                    KategorijaID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Potkategorija", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Potkategorija_Kategorija_KategorijaID",
                        column: x => x.KategorijaID,
                        principalTable: "Kategorija",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Ime = table.Column<string>(nullable: true),
                    Prezime = table.Column<string>(nullable: true),
                    DatumRodjenja = table.Column<DateTime>(nullable: false),
                    AdresaID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Adresa_AdresaID",
                        column: x => x.AdresaID,
                        principalTable: "Adresa",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateTable(
                name: "Velicina",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VelicinaOznaka = table.Column<string>(nullable: true),
                    PotkategorijaID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Velicina", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Velicina_Potkategorija_PotkategorijaID",
                        column: x => x.PotkategorijaID,
                        principalTable: "Potkategorija",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LogKretanjePoSistemu",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KorisnikID = table.Column<string>(nullable: true),
                    QueryPath = table.Column<string>(nullable: true),
                    PostData = table.Column<string>(nullable: true),
                    Vrijeme = table.Column<DateTime>(nullable: false),
                    IpAdresa = table.Column<string>(nullable: true),
                    exceptionMessage = table.Column<string>(nullable: true),
                    isException = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogKretanjePoSistemu", x => x.ID);
                    table.ForeignKey(
                        name: "FK_LogKretanjePoSistemu_AspNetUsers_KorisnikID",
                        column: x => x.KorisnikID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Artikal",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true),
                    KategorijaID = table.Column<int>(nullable: false),
                    PotkategorijaID = table.Column<int>(nullable: false),
                    ProdavacID = table.Column<string>(nullable: true),
                    ImeProdavaca = table.Column<string>(nullable: true),
                    Cijena = table.Column<float>(nullable: false),
                    CijenaSaPopustom = table.Column<float>(nullable: false),
                    BrendID = table.Column<int>(nullable: false),
                    BrojUSkladistu = table.Column<int>(nullable: false),
                    BojaID = table.Column<int>(nullable: true),
                    MaterijalID = table.Column<int>(nullable: true),
                    VelicinaID = table.Column<int>(nullable: true),
                    DatumObjave = table.Column<DateTime>(nullable: false),
                    Izbrisan = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artikal", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Artikal_Boja_BojaID",
                        column: x => x.BojaID,
                        principalTable: "Boja",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Artikal_Brend_BrendID",
                        column: x => x.BrendID,
                        principalTable: "Brend",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Artikal_Kategorija_KategorijaID",
                        column: x => x.KategorijaID,
                        principalTable: "Kategorija",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Artikal_Materijal_MaterijalID",
                        column: x => x.MaterijalID,
                        principalTable: "Materijal",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Artikal_Potkategorija_PotkategorijaID",
                        column: x => x.PotkategorijaID,
                        principalTable: "Potkategorija",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Artikal_Velicina_VelicinaID",
                        column: x => x.VelicinaID,
                        principalTable: "Velicina",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

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
                    table.ForeignKey(
                        name: "FK_Korpa_Artikal_ArtikalID",
                        column: x => x.ArtikalID,
                        principalTable: "Artikal",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Korpa_AspNetUsers_KupacID",
                        column: x => x.KupacID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ListaZelja",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KupacID = table.Column<string>(nullable: true),
                    ArtikalID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListaZelja", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ListaZelja_Artikal_ArtikalID",
                        column: x => x.ArtikalID,
                        principalTable: "Artikal",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ListaZelja_AspNetUsers_KupacID",
                        column: x => x.KupacID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Slika",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naslov = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Naziv = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    SlikaFile = table.Column<byte[]>(nullable: true),
                    ArtikalID = table.Column<int>(nullable: false),
                    Thumbnail = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slika", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Slika_Artikal_ArtikalID",
                        column: x => x.ArtikalID,
                        principalTable: "Artikal",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
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
                    RejtingID = table.Column<int>(nullable: true),
                    SlikaID = table.Column<int>(nullable: true)
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
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ZavrseniArtikal_Slika_SlikaID",
                        column: x => x.SlikaID,
                        principalTable: "Slika",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adresa_OpcinaID",
                table: "Adresa",
                column: "OpcinaID");

            migrationBuilder.CreateIndex(
                name: "IX_Artikal_BojaID",
                table: "Artikal",
                column: "BojaID");

            migrationBuilder.CreateIndex(
                name: "IX_Artikal_BrendID",
                table: "Artikal",
                column: "BrendID");

            migrationBuilder.CreateIndex(
                name: "IX_Artikal_KategorijaID",
                table: "Artikal",
                column: "KategorijaID");

            migrationBuilder.CreateIndex(
                name: "IX_Artikal_MaterijalID",
                table: "Artikal",
                column: "MaterijalID");

            migrationBuilder.CreateIndex(
                name: "IX_Artikal_PotkategorijaID",
                table: "Artikal",
                column: "PotkategorijaID");

            migrationBuilder.CreateIndex(
                name: "IX_Artikal_VelicinaID",
                table: "Artikal",
                column: "VelicinaID");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_AdresaID",
                table: "AspNetUsers",
                column: "AdresaID");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Korpa_ArtikalID",
                table: "Korpa",
                column: "ArtikalID");

            migrationBuilder.CreateIndex(
                name: "IX_Korpa_KupacID",
                table: "Korpa",
                column: "KupacID");

            migrationBuilder.CreateIndex(
                name: "IX_ListaZelja_ArtikalID",
                table: "ListaZelja",
                column: "ArtikalID");

            migrationBuilder.CreateIndex(
                name: "IX_ListaZelja_KupacID",
                table: "ListaZelja",
                column: "KupacID");

            migrationBuilder.CreateIndex(
                name: "IX_LogKretanjePoSistemu_KorisnikID",
                table: "LogKretanjePoSistemu",
                column: "KorisnikID");

            migrationBuilder.CreateIndex(
                name: "IX_Ponuda_KategorijaID",
                table: "Ponuda",
                column: "KategorijaID");

            migrationBuilder.CreateIndex(
                name: "IX_Ponuda_PotkategorijaID",
                table: "Ponuda",
                column: "PotkategorijaID");

            migrationBuilder.CreateIndex(
                name: "IX_Potkategorija_KategorijaID",
                table: "Potkategorija",
                column: "KategorijaID");

            migrationBuilder.CreateIndex(
                name: "IX_Slika_ArtikalID",
                table: "Slika",
                column: "ArtikalID");

            migrationBuilder.CreateIndex(
                name: "IX_Velicina_PotkategorijaID",
                table: "Velicina",
                column: "PotkategorijaID");

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

            migrationBuilder.CreateIndex(
                name: "IX_ZavrseniArtikal_SlikaID",
                table: "ZavrseniArtikal",
                column: "SlikaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Korpa");

            migrationBuilder.DropTable(
                name: "ListaZelja");

            migrationBuilder.DropTable(
                name: "LogKretanjePoSistemu");

            migrationBuilder.DropTable(
                name: "Ponuda");

            migrationBuilder.DropTable(
                name: "Poruka");

            migrationBuilder.DropTable(
                name: "ZavrseniArtikal");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Rejting");

            migrationBuilder.DropTable(
                name: "Slika");

            migrationBuilder.DropTable(
                name: "Adresa");

            migrationBuilder.DropTable(
                name: "Artikal");

            migrationBuilder.DropTable(
                name: "Grad");

            migrationBuilder.DropTable(
                name: "Boja");

            migrationBuilder.DropTable(
                name: "Brend");

            migrationBuilder.DropTable(
                name: "Materijal");

            migrationBuilder.DropTable(
                name: "Velicina");

            migrationBuilder.DropTable(
                name: "Potkategorija");

            migrationBuilder.DropTable(
                name: "Kategorija");
        }
    }
}
