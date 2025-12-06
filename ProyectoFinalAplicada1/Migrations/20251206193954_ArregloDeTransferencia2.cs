using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoFinalAplicada1.Migrations
{
    /// <inheritdoc />
    public partial class ArregloDeTransferencia2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transferencia_Cliente_TransferenciaId",
                table: "Transferencia");

            migrationBuilder.AlterColumn<int>(
                name: "PedidoId",
                table: "Transferencia",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "Transferencia",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transferencia_ClienteId",
                table: "Transferencia",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Transferencia_PedidoId",
                table: "Transferencia",
                column: "PedidoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transferencia_Cliente_ClienteId",
                table: "Transferencia",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transferencia_Pedido_PedidoId",
                table: "Transferencia",
                column: "PedidoId",
                principalTable: "Pedido",
                principalColumn: "PedidoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transferencia_Cliente_ClienteId",
                table: "Transferencia");

            migrationBuilder.DropForeignKey(
                name: "FK_Transferencia_Pedido_PedidoId",
                table: "Transferencia");

            migrationBuilder.DropIndex(
                name: "IX_Transferencia_ClienteId",
                table: "Transferencia");

            migrationBuilder.DropIndex(
                name: "IX_Transferencia_PedidoId",
                table: "Transferencia");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Transferencia");

            migrationBuilder.AlterColumn<int>(
                name: "PedidoId",
                table: "Transferencia",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

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
