using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoFinalAplicada1.Migrations
{
    /// <inheritdoc />
    public partial class ArregloDePedidoCliente2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PedidoDetalle_Pedido_DetalleId",
                table: "PedidoDetalle");

            migrationBuilder.AlterColumn<int>(
                name: "DetalleId",
                table: "PedidoDetalle",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.CreateIndex(
                name: "IX_PedidoDetalle_PedidoId",
                table: "PedidoDetalle",
                column: "PedidoId");

            migrationBuilder.AddForeignKey(
                name: "FK_PedidoDetalle_Pedido_PedidoId",
                table: "PedidoDetalle",
                column: "PedidoId",
                principalTable: "Pedido",
                principalColumn: "PedidoId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PedidoDetalle_Pedido_PedidoId",
                table: "PedidoDetalle");

            migrationBuilder.DropIndex(
                name: "IX_PedidoDetalle_PedidoId",
                table: "PedidoDetalle");

            migrationBuilder.AlterColumn<int>(
                name: "DetalleId",
                table: "PedidoDetalle",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddForeignKey(
                name: "FK_PedidoDetalle_Pedido_DetalleId",
                table: "PedidoDetalle",
                column: "DetalleId",
                principalTable: "Pedido",
                principalColumn: "PedidoId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
