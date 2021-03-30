using Microsoft.EntityFrameworkCore.Migrations;

namespace eKorpa.Migrations
{
    public partial class brend : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BrendID",
                table: "Artikal",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Brend",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brend", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Artikal_BrendID",
                table: "Artikal",
                column: "BrendID");

            migrationBuilder.AddForeignKey(
                name: "FK_Artikal_Brend_BrendID",
                table: "Artikal",
                column: "BrendID",
                principalTable: "Brend",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artikal_Brend_BrendID",
                table: "Artikal");

            migrationBuilder.DropTable(
                name: "Brend");

            migrationBuilder.DropIndex(
                name: "IX_Artikal_BrendID",
                table: "Artikal");

            migrationBuilder.DropColumn(
                name: "BrendID",
                table: "Artikal");
        }
    }
}
