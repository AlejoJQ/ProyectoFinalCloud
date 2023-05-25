using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Disquera.API.Migrations
{
    /// <inheritdoc />
    public partial class v01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Autores",
                columns: table => new
                {
                    id_autor = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nombre = table.Column<string>(type: "TEXT", nullable: true),
                    nacionalidad = table.Column<string>(type: "TEXT", nullable: true),
                    edad = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autores", x => x.id_autor);
                });

            migrationBuilder.CreateTable(
                name: "Canciones",
                columns: table => new
                {
                    id_cancion = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nombre = table.Column<string>(type: "TEXT", nullable: true),
                    reproducciones = table.Column<string>(type: "TEXT", nullable: true),
                    genero = table.Column<string>(type: "TEXT", nullable: true),
                    Autorid_autor = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Canciones", x => x.id_cancion);
                    table.ForeignKey(
                        name: "FK_Canciones_Autores_Autorid_autor",
                        column: x => x.Autorid_autor,
                        principalTable: "Autores",
                        principalColumn: "id_autor");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Canciones_Autorid_autor",
                table: "Canciones",
                column: "Autorid_autor");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Canciones");

            migrationBuilder.DropTable(
                name: "Autores");
        }
    }
}
