using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoFinalAplicada1.Migrations
{
    /// <inheritdoc />
    public partial class AgremandoClienteId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transferencia_Cliente_TransferenciaId",
                table: "Transferencia");

            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "Transferencia",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transferencia_ClienteId",
                table: "Transferencia",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transferencia_Cliente_ClienteId",
                table: "Transferencia",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "ClienteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transferencia_Cliente_ClienteId",
                table: "Transferencia");

            migrationBuilder.DropIndex(
                name: "IX_Transferencia_ClienteId",
                table: "Transferencia");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Transferencia");

            migrationBuilder.AddForeignKey(
                name: "FK_Transferencia_Cliente_TransferenciaId",
                table: "Transferencia",
                column: "TransferenciaId",
                principalTable: "Cliente",
                principalColumn: "ClienteId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
