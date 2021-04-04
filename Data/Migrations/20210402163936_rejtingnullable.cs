using Microsoft.EntityFrameworkCore.Migrations;

namespace eKorpa.Migrations
{
    public partial class rejtingnullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ZavrseniArtikal_Rejting_RejtingID",
                table: "ZavrseniArtikal");

            migrationBuilder.AlterColumn<int>(
                name: "RejtingID",
                table: "ZavrseniArtikal",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ZavrseniArtikal_Rejting_RejtingID",
                table: "ZavrseniArtikal",
                column: "RejtingID",
                principalTable: "Rejting",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ZavrseniArtikal_Rejting_RejtingID",
                table: "ZavrseniArtikal");

            migrationBuilder.AlterColumn<int>(
                name: "RejtingID",
                table: "ZavrseniArtikal",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ZavrseniArtikal_Rejting_RejtingID",
                table: "ZavrseniArtikal",
                column: "RejtingID",
                principalTable: "Rejting",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
