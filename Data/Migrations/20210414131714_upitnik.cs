using Microsoft.EntityFrameworkCore.Migrations;

namespace eKorpa.Migrations
{
    public partial class upitnik : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adresa_Grad_OpcinaID",
                table: "Adresa");

            migrationBuilder.AlterColumn<int>(
                name: "OpcinaID",
                table: "Adresa",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Adresa_Grad_OpcinaID",
                table: "Adresa",
                column: "OpcinaID",
                principalTable: "Grad",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adresa_Grad_OpcinaID",
                table: "Adresa");

            migrationBuilder.AlterColumn<int>(
                name: "OpcinaID",
                table: "Adresa",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Adresa_Grad_OpcinaID",
                table: "Adresa",
                column: "OpcinaID",
                principalTable: "Grad",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
