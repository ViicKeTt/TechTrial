using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace T.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Modificando_campo_metricas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TiempoRespuestaSegundos",
                table: "Metricas",
                newName: "TiempoRespuestaMiliSegundos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TiempoRespuestaMiliSegundos",
                table: "Metricas",
                newName: "TiempoRespuestaSegundos");
        }
    }
}
