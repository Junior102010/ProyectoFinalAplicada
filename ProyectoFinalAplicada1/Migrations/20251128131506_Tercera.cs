using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoFinalAplicada1.Migrations
{
    /// <inheritdoc />
    public partial class Tercera : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Entrada_ProveedorId",
                table: "Entrada",
                column: "ProveedorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Entrada_Proveedor_ProveedorId",
                table: "Entrada",
                column: "ProveedorId",
                principalTable: "Proveedor",
                principalColumn: "ProveedorId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entrada_Proveedor_ProveedorId",
                table: "Entrada");

            migrationBuilder.DropIndex(
                name: "IX_Entrada_ProveedorId",
                table: "Entrada");
        }
    }
}
