using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace T.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Modificando_campos_metricas2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Metricas",
                newName: "DateUtc");

            migrationBuilder.RenameColumn(
                name: "ConsumoPeticion",
                table: "Metricas",
                newName: "ConsumoPeticionBytes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateUtc",
                table: "Metricas",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "ConsumoPeticionBytes",
                table: "Metricas",
                newName: "ConsumoPeticion");
        }
    }
}
