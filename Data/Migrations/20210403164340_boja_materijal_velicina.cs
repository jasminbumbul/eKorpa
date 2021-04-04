using Microsoft.EntityFrameworkCore.Migrations;

namespace eKorpa.Migrations
{
    public partial class boja_materijal_velicina : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BojaID",
                table: "Artikal",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaterijalID",
                table: "Artikal",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VelicinaID",
                table: "Artikal",
                nullable: false,
                defaultValue: 0);

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
                name: "Materijal",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true),
                    SastavProcenat = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materijal", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Velicina",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VelicinaBroj = table.Column<int>(nullable: false),
                    VelicinaOznaka = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Velicina", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Artikal_BojaID",
                table: "Artikal",
                column: "BojaID");

            migrationBuilder.CreateIndex(
                name: "IX_Artikal_MaterijalID",
                table: "Artikal",
                column: "MaterijalID");

            migrationBuilder.CreateIndex(
                name: "IX_Artikal_VelicinaID",
                table: "Artikal",
                column: "VelicinaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Artikal_Boja_BojaID",
                table: "Artikal",
                column: "BojaID",
                principalTable: "Boja",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Artikal_Materijal_MaterijalID",
                table: "Artikal",
                column: "MaterijalID",
                principalTable: "Materijal",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Artikal_Velicina_VelicinaID",
                table: "Artikal",
                column: "VelicinaID",
                principalTable: "Velicina",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artikal_Boja_BojaID",
                table: "Artikal");

            migrationBuilder.DropForeignKey(
                name: "FK_Artikal_Materijal_MaterijalID",
                table: "Artikal");

            migrationBuilder.DropForeignKey(
                name: "FK_Artikal_Velicina_VelicinaID",
                table: "Artikal");

            migrationBuilder.DropTable(
                name: "Boja");

            migrationBuilder.DropTable(
                name: "Materijal");

            migrationBuilder.DropTable(
                name: "Velicina");

            migrationBuilder.DropIndex(
                name: "IX_Artikal_BojaID",
                table: "Artikal");

            migrationBuilder.DropIndex(
                name: "IX_Artikal_MaterijalID",
                table: "Artikal");

            migrationBuilder.DropIndex(
                name: "IX_Artikal_VelicinaID",
                table: "Artikal");

            migrationBuilder.DropColumn(
                name: "BojaID",
                table: "Artikal");

            migrationBuilder.DropColumn(
                name: "MaterijalID",
                table: "Artikal");

            migrationBuilder.DropColumn(
                name: "VelicinaID",
                table: "Artikal");
        }
    }
}
