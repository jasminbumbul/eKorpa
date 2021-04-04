using Microsoft.EntityFrameworkCore.Migrations;

namespace eKorpa.Migrations
{
    public partial class fixnullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<int>(
                name: "VelicinaID",
                table: "Artikal",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MaterijalID",
                table: "Artikal",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "BojaID",
                table: "Artikal",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Artikal_Boja_BojaID",
                table: "Artikal",
                column: "BojaID",
                principalTable: "Boja",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Artikal_Materijal_MaterijalID",
                table: "Artikal",
                column: "MaterijalID",
                principalTable: "Materijal",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Artikal_Velicina_VelicinaID",
                table: "Artikal",
                column: "VelicinaID",
                principalTable: "Velicina",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
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

            migrationBuilder.AlterColumn<int>(
                name: "VelicinaID",
                table: "Artikal",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MaterijalID",
                table: "Artikal",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BojaID",
                table: "Artikal",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Artikal_Boja_BojaID",
                table: "Artikal",
                column: "BojaID",
                principalTable: "Boja",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

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
    }
}
