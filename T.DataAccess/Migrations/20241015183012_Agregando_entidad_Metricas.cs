using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace T.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Agregando_entidad_Metricas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Metricas",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HttpCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ConsumoPeticion = table.Column<double>(type: "float", nullable: false),
                    TiempoRespuestaSegundos = table.Column<double>(type: "float", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Controller = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Action = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Metricas", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Metricas");
        }
    }
}
