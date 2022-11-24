using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace proiect_mari_claudiu.Migrations
{
    public partial class Model : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ModelID",
                table: "Masina",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Model",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeModel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descriere = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Model", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Masina_ModelID",
                table: "Masina",
                column: "ModelID");

            migrationBuilder.AddForeignKey(
                name: "FK_Masina_Model_ModelID",
                table: "Masina",
                column: "ModelID",
                principalTable: "Model",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Masina_Model_ModelID",
                table: "Masina");

            migrationBuilder.DropTable(
                name: "Model");

            migrationBuilder.DropIndex(
                name: "IX_Masina_ModelID",
                table: "Masina");

            migrationBuilder.DropColumn(
                name: "ModelID",
                table: "Masina");
        }
    }
}
