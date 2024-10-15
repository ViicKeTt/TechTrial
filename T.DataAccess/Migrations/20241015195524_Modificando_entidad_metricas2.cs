using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace T.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Modificando_entidad_metricas2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HttpCode",
                table: "Metricas",
                newName: "Http");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Http",
                table: "Metricas",
                newName: "HttpCode");
        }
    }
}
