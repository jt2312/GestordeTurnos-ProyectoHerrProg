using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HerramientasProgFinal.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ConsultorioId",
                table: "Doctor",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DoctorId",
                table: "Citacion",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PacienteId",
                table: "Citacion",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_ConsultorioId",
                table: "Doctor",
                column: "ConsultorioId");

            migrationBuilder.CreateIndex(
                name: "IX_Citacion_DoctorId",
                table: "Citacion",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Citacion_PacienteId",
                table: "Citacion",
                column: "PacienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Citacion_Doctor_DoctorId",
                table: "Citacion",
                column: "DoctorId",
                principalTable: "Doctor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Citacion_Paciente_PacienteId",
                table: "Citacion",
                column: "PacienteId",
                principalTable: "Paciente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Doctor_Consultorio_ConsultorioId",
                table: "Doctor",
                column: "ConsultorioId",
                principalTable: "Consultorio",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Citacion_Doctor_DoctorId",
                table: "Citacion");

            migrationBuilder.DropForeignKey(
                name: "FK_Citacion_Paciente_PacienteId",
                table: "Citacion");

            migrationBuilder.DropForeignKey(
                name: "FK_Doctor_Consultorio_ConsultorioId",
                table: "Doctor");

            migrationBuilder.DropIndex(
                name: "IX_Doctor_ConsultorioId",
                table: "Doctor");

            migrationBuilder.DropIndex(
                name: "IX_Citacion_DoctorId",
                table: "Citacion");

            migrationBuilder.DropIndex(
                name: "IX_Citacion_PacienteId",
                table: "Citacion");

            migrationBuilder.DropColumn(
                name: "ConsultorioId",
                table: "Doctor");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "Citacion");

            migrationBuilder.DropColumn(
                name: "PacienteId",
                table: "Citacion");
        }
    }
}
