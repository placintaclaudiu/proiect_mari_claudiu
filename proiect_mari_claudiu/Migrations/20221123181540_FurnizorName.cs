using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace proiect_mari_claudiu.Migrations
{
    public partial class FurnizorName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Pret",
                table: "Masina",
                type: "decimal(8,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<int>(
                name: "FurnizorID",
                table: "Masina",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Furnizor",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Furnizor", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Masina_FurnizorID",
                table: "Masina",
                column: "FurnizorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Masina_Furnizor_FurnizorID",
                table: "Masina",
                column: "FurnizorID",
                principalTable: "Furnizor",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Masina_Furnizor_FurnizorID",
                table: "Masina");

            migrationBuilder.DropTable(
                name: "Furnizor");

            migrationBuilder.DropIndex(
                name: "IX_Masina_FurnizorID",
                table: "Masina");

            migrationBuilder.DropColumn(
                name: "FurnizorID",
                table: "Masina");

            migrationBuilder.AlterColumn<decimal>(
                name: "Pret",
                table: "Masina",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(8,2)");
        }
    }
}
