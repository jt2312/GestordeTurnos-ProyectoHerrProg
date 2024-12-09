using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HerramientasProgFinal.Migrations
{
    /// <inheritdoc />
    public partial class AddEstadoToCita : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EstadoActual",
                table: "Citacion",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EstadoActual",
                table: "Citacion");
        }
    }
}
