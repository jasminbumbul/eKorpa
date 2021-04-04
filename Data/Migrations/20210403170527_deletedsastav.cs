using Microsoft.EntityFrameworkCore.Migrations;

namespace eKorpa.Migrations
{
    public partial class deletedsastav : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SastavProcenat",
                table: "Materijal");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "SastavProcenat",
                table: "Materijal",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
