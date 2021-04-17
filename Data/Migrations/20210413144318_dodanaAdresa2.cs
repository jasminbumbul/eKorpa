using Microsoft.EntityFrameworkCore.Migrations;

namespace eKorpa.Migrations
{
    public partial class dodanaAdresa2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AdresaID",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_AdresaID",
                table: "AspNetUsers",
                column: "AdresaID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Adresa_AdresaID",
                table: "AspNetUsers",
                column: "AdresaID",
                principalTable: "Adresa",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Adresa_AdresaID",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_AdresaID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AdresaID",
                table: "AspNetUsers");
        }
    }
}
