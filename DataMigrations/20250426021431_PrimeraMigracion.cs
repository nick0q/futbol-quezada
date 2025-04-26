using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace futbol.DataMigrations
{
    /// <inheritdoc />
    public partial class PrimeraMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "t_equipos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_equipos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "t_jugadores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false),
                    Edad = table.Column<int>(type: "INTEGER", nullable: false),
                    Posicion = table.Column<string>(type: "TEXT", nullable: false),
                    EquipoActual = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_jugadores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "t_jugadorEquipo",
                columns: table => new
                {
                    PlayerId = table.Column<int>(type: "INTEGER", nullable: false),
                    TeamId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_jugadorEquipo", x => new { x.PlayerId, x.TeamId });
                    table.ForeignKey(
                        name: "FK_t_jugadorEquipo_t_equipos_TeamId",
                        column: x => x.TeamId,
                        principalTable: "t_equipos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_t_jugadorEquipo_t_jugadores_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "t_jugadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_t_jugadorEquipo_TeamId",
                table: "t_jugadorEquipo",
                column: "TeamId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "t_jugadorEquipo");

            migrationBuilder.DropTable(
                name: "t_equipos");

            migrationBuilder.DropTable(
                name: "t_jugadores");
        }
    }
}
