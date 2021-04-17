using Microsoft.EntityFrameworkCore.Migrations;

namespace eKorpa.Migrations
{
    public partial class fixratinga : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ocjena",
                table: "Rejting");

            migrationBuilder.DropColumn(
                name: "Opis",
                table: "Rejting");

            migrationBuilder.AddColumn<string>(
                name: "DojamKupca",
                table: "Rejting",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DojamProdavaca",
                table: "Rejting",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "KupacOstavioDojam",
                table: "Rejting",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<float>(
                name: "OcjenaKupca",
                table: "Rejting",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "OcjenaProdavaca",
                table: "Rejting",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<bool>(
                name: "ProdavacOstavioDojam",
                table: "Rejting",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DojamKupca",
                table: "Rejting");

            migrationBuilder.DropColumn(
                name: "DojamProdavaca",
                table: "Rejting");

            migrationBuilder.DropColumn(
                name: "KupacOstavioDojam",
                table: "Rejting");

            migrationBuilder.DropColumn(
                name: "OcjenaKupca",
                table: "Rejting");

            migrationBuilder.DropColumn(
                name: "OcjenaProdavaca",
                table: "Rejting");

            migrationBuilder.DropColumn(
                name: "ProdavacOstavioDojam",
                table: "Rejting");

            migrationBuilder.AddColumn<float>(
                name: "Ocjena",
                table: "Rejting",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "Opis",
                table: "Rejting",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
