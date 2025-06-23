using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Geometria.Migrations
{
    /// <inheritdoc />
    public partial class AddVolumenToShapes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Volumen",
                table: "Triangulos",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Volumen",
                table: "Rectangulos",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Volumen",
                table: "Cuadrados",
                type: "double",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Volumen",
                table: "Triangulos");

            migrationBuilder.DropColumn(
                name: "Volumen",
                table: "Rectangulos");

            migrationBuilder.DropColumn(
                name: "Volumen",
                table: "Cuadrados");
        }
    }
}
