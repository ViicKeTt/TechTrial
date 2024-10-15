using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace T.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Modificando_entidad_metricas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Action",
                table: "Metricas");

            migrationBuilder.DropColumn(
                name: "Controller",
                table: "Metricas");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Metricas",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Metricas");

            migrationBuilder.AddColumn<string>(
                name: "Action",
                table: "Metricas",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Controller",
                table: "Metricas",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "");
        }
    }
}
