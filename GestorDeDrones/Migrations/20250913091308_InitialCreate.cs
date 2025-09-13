using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestorDeDrones.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Drones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Marca = table.Column<string>(type: "TEXT", nullable: false),
                    Modelo = table.Column<string>(type: "TEXT", nullable: false),
                    NumeroSerie = table.Column<string>(type: "TEXT", nullable: false),
                    Peso = table.Column<double>(type: "REAL", nullable: false),
                    Clase = table.Column<string>(type: "TEXT", nullable: false),
                    Anio = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Accesorios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false),
                    Marca = table.Column<string>(type: "TEXT", nullable: false),
                    Modelo = table.Column<string>(type: "TEXT", nullable: false),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: false),
                    CiclosDeCarga = table.Column<int>(type: "INTEGER", nullable: false),
                    AnioCompra = table.Column<int>(type: "INTEGER", nullable: false),
                    DroneId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accesorios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accesorios_Drones_DroneId",
                        column: x => x.DroneId,
                        principalTable: "Drones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Baterias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false),
                    NumeroSerie = table.Column<string>(type: "TEXT", nullable: false),
                    CiclosDeCarga = table.Column<int>(type: "INTEGER", nullable: false),
                    AnioCompra = table.Column<int>(type: "INTEGER", nullable: false),
                    DroneId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Baterias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Baterias_Drones_DroneId",
                        column: x => x.DroneId,
                        principalTable: "Drones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Mandos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Marca = table.Column<string>(type: "TEXT", nullable: false),
                    Modelo = table.Column<string>(type: "TEXT", nullable: false),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: false),
                    CiclosDeCarga = table.Column<int>(type: "INTEGER", nullable: false),
                    AnioCompra = table.Column<int>(type: "INTEGER", nullable: false),
                    DroneId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mandos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mandos_Drones_DroneId",
                        column: x => x.DroneId,
                        principalTable: "Drones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accesorios_DroneId",
                table: "Accesorios",
                column: "DroneId");

            migrationBuilder.CreateIndex(
                name: "IX_Baterias_DroneId",
                table: "Baterias",
                column: "DroneId");

            migrationBuilder.CreateIndex(
                name: "IX_Mandos_DroneId",
                table: "Mandos",
                column: "DroneId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accesorios");

            migrationBuilder.DropTable(
                name: "Baterias");

            migrationBuilder.DropTable(
                name: "Mandos");

            migrationBuilder.DropTable(
                name: "Drones");
        }
    }
}
