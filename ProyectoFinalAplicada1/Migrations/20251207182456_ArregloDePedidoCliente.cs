using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoFinalAplicada1.Migrations
{
    /// <inheritdoc />
    public partial class ArregloDePedidoCliente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transferencia_PedidoDetalle_TransferenciaId",
                table: "Transferencia");

            migrationBuilder.AlterColumn<int>(
                name: "TransferenciaId",
                table: "Transferencia",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TransferenciaId",
                table: "Transferencia",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddForeignKey(
                name: "FK_Transferencia_PedidoDetalle_TransferenciaId",
                table: "Transferencia",
                column: "TransferenciaId",
                principalTable: "PedidoDetalle",
                principalColumn: "DetalleId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
