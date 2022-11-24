using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace proiect_mari_claudiu.Migrations
{
    public partial class NumeFurnizor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nume",
                table: "Furnizor",
                newName: "NumeFurnizor");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NumeFurnizor",
                table: "Furnizor",
                newName: "Nume");
        }
    }
}
