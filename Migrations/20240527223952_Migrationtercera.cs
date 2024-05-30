using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HerramientasProgFinal.Migrations
{
    /// <inheritdoc />
    public partial class Migrationtercera : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Doctor",
                newName: "Nombre");
        }   

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
            name: "Nombre",
            table: "Doctor",
            newName: "Name");
        }
    }
}
