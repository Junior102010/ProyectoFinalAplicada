using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoFinalAplicada1.Migrations.ApplicationDb
{
    /// <inheritdoc />
    public partial class InicialEmpresa2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "EsEmpresa",
                table: "AspNetUsers",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "RNC",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RazonSocial",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TelefonoNegocio",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EsEmpresa",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RNC",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RazonSocial",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TelefonoNegocio",
                table: "AspNetUsers");
        }
    }
}
