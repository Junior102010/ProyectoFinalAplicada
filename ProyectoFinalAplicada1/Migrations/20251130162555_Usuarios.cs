using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoFinalAplicada1.Migrations
{
    /// <inheritdoc />
    public partial class Usuarios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PedidoDetalle_Pedido_PedidoId",
                table: "PedidoDetalle");

            migrationBuilder.DropForeignKey(
                name: "FK_Transferencia_Usuario_UsuarioId",
                table: "Transferencia");

            migrationBuilder.DropIndex(
                name: "IX_Transferencia_UsuarioId",
                table: "Transferencia");

            migrationBuilder.DropIndex(
                name: "IX_PedidoDetalle_PedidoId",
                table: "PedidoDetalle");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Transferencia");

            migrationBuilder.RenameColumn(
                name: "ContrasenaCliente",
                table: "Cliente",
                newName: "UserId");

            migrationBuilder.AlterColumn<int>(
                name: "TransferenciaId",
                table: "Transferencia",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<int>(
                name: "DetalleId",
                table: "PedidoDetalle",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<int>(
                name: "CategoriaId",
                table: "Categoria",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.CreateTable(
                name: "ApplicationUser",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    NombreCliente = table.Column<string>(type: "TEXT", nullable: false),
                    ApellidoCliente = table.Column<string>(type: "TEXT", nullable: false),
                    TelefonoCliente = table.Column<string>(type: "TEXT", nullable: false),
                    Sector = table.Column<string>(type: "TEXT", nullable: false),
                    CalleCliente = table.Column<string>(type: "TEXT", nullable: false),
                    ViviendaCliente = table.Column<string>(type: "TEXT", nullable: false),
                    DescripcionCliente = table.Column<string>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TransferenciaImagenes",
                columns: table => new
                {
                    TransferenciaImagenId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TransferenciaId = table.Column<int>(type: "INTEGER", nullable: false),
                    RutaImagen = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransferenciaImagenes", x => x.TransferenciaImagenId);
                    table.ForeignKey(
                        name: "FK_TransferenciaImagenes_Transferencia_TransferenciaId",
                        column: x => x.TransferenciaId,
                        principalTable: "Transferencia",
                        principalColumn: "TransferenciaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_UserId",
                table: "Cliente",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TransferenciaImagenes_TransferenciaId",
                table: "TransferenciaImagenes",
                column: "TransferenciaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categoria_Proveedor_CategoriaId",
                table: "Categoria",
                column: "CategoriaId",
                principalTable: "Proveedor",
                principalColumn: "ProveedorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cliente_ApplicationUser_UserId",
                table: "Cliente",
                column: "UserId",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PedidoDetalle_Pedido_DetalleId",
                table: "PedidoDetalle",
                column: "DetalleId",
                principalTable: "Pedido",
                principalColumn: "PedidoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transferencia_Cliente_TransferenciaId",
                table: "Transferencia",
                column: "TransferenciaId",
                principalTable: "Cliente",
                principalColumn: "ClienteId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transferencia_PedidoDetalle_TransferenciaId",
                table: "Transferencia",
                column: "TransferenciaId",
                principalTable: "PedidoDetalle",
                principalColumn: "DetalleId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categoria_Proveedor_CategoriaId",
                table: "Categoria");

            migrationBuilder.DropForeignKey(
                name: "FK_Cliente_ApplicationUser_UserId",
                table: "Cliente");

            migrationBuilder.DropForeignKey(
                name: "FK_PedidoDetalle_Pedido_DetalleId",
                table: "PedidoDetalle");

            migrationBuilder.DropForeignKey(
                name: "FK_Transferencia_Cliente_TransferenciaId",
                table: "Transferencia");

            migrationBuilder.DropForeignKey(
                name: "FK_Transferencia_PedidoDetalle_TransferenciaId",
                table: "Transferencia");

            migrationBuilder.DropTable(
                name: "ApplicationUser");

            migrationBuilder.DropTable(
                name: "TransferenciaImagenes");

            migrationBuilder.DropIndex(
                name: "IX_Cliente_UserId",
                table: "Cliente");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Cliente",
                newName: "ContrasenaCliente");

            migrationBuilder.AlterColumn<int>(
                name: "TransferenciaId",
                table: "Transferencia",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Transferencia",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "DetalleId",
                table: "PedidoDetalle",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<int>(
                name: "CategoriaId",
                table: "Categoria",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.CreateIndex(
                name: "IX_Transferencia_UsuarioId",
                table: "Transferencia",
                column: "UsuarioId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Transferencia_Usuario_UsuarioId",
                table: "Transferencia",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
