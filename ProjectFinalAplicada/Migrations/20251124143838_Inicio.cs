using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoFinalAplicada.Migrations;

/// <inheritdoc />
public partial class Inicio : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Admin",
            columns: table => new
            {
                Id_Admin = table.Column<int>(type: "INTEGER", nullable: false)
                    .Annotation("Sqlite:Autoincrement", true),
                NombreAdmin = table.Column<string>(type: "TEXT", nullable: false),
                ApellidoAdmin = table.Column<string>(type: "TEXT", nullable: false),
                TelefonoAdmin = table.Column<string>(type: "TEXT", nullable: false),
                ContrasenaAdmin = table.Column<string>(type: "TEXT", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Admin", x => x.Id_Admin);
            });

        migrationBuilder.CreateTable(
            name: "Cliente",
            columns: table => new
            {
                Id_Cliente = table.Column<int>(type: "INTEGER", nullable: false)
                    .Annotation("Sqlite:Autoincrement", true),
                NombreCliente = table.Column<string>(type: "TEXT", nullable: false),
                ApellidoCliente = table.Column<string>(type: "TEXT", nullable: false),
                TelefonoCliente = table.Column<string>(type: "TEXT", nullable: false),
                ContrasenaCliente = table.Column<string>(type: "TEXT", nullable: false),
                Sector = table.Column<string>(type: "TEXT", nullable: false),
                CalleCliente = table.Column<string>(type: "TEXT", nullable: false),
                NumViviendaCliente = table.Column<string>(type: "TEXT", nullable: false),
                DescripcionCliente = table.Column<string>(type: "TEXT", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Cliente", x => x.Id_Cliente);
            });

        migrationBuilder.CreateTable(
            name: "Entrada",
            columns: table => new
            {
                Id_Entrada = table.Column<int>(type: "INTEGER", nullable: false)
                    .Annotation("Sqlite:Autoincrement", true),
                FechaEntrada = table.Column<DateTime>(type: "TEXT", nullable: false),
                RefFactura = table.Column<string>(type: "TEXT", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Entrada", x => x.Id_Entrada);
            });

        migrationBuilder.CreateTable(
            name: "Transferencia",
            columns: table => new
            {
                Id_Transferencia = table.Column<int>(type: "INTEGER", nullable: false)
                    .Annotation("Sqlite:Autoincrement", true),
                NumTransferencia = table.Column<string>(type: "TEXT", nullable: false),
                FechaTransferencia = table.Column<DateTime>(type: "TEXT", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Transferencia", x => x.Id_Transferencia);
            });

        migrationBuilder.CreateTable(
            name: "Proveedor",
            columns: table => new
            {
                Id_Proveedor = table.Column<int>(type: "INTEGER", nullable: false),
                NombreProveedor = table.Column<string>(type: "TEXT", nullable: false),
                TelefonoProveedor = table.Column<string>(type: "TEXT", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Proveedor", x => x.Id_Proveedor);
                table.ForeignKey(
                    name: "FK_Proveedor_Entrada_Id_Proveedor",
                    column: x => x.Id_Proveedor,
                    principalTable: "Entrada",
                    principalColumn: "Id_Entrada",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "Pedido",
            columns: table => new
            {
                Id_Pedido = table.Column<int>(type: "INTEGER", nullable: false),
                NombreCliente = table.Column<string>(type: "TEXT", nullable: false),
                TelefonoCliente = table.Column<string>(type: "TEXT", nullable: false),
                RefSitio = table.Column<string>(type: "TEXT", nullable: false),
                FechaPedido = table.Column<DateTime>(type: "TEXT", nullable: false),
                Estado = table.Column<string>(type: "TEXT", nullable: false),
                Cantidad = table.Column<double>(type: "REAL", nullable: false),
                MontoTotal = table.Column<double>(type: "REAL", nullable: false),
                Deliveri = table.Column<bool>(type: "INTEGER", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Pedido", x => x.Id_Pedido);
                table.ForeignKey(
                    name: "FK_Pedido_Transferencia_Id_Pedido",
                    column: x => x.Id_Pedido,
                    principalTable: "Transferencia",
                    principalColumn: "Id_Transferencia",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "TipoProducto",
            columns: table => new
            {
                Id_Tipo = table.Column<int>(type: "INTEGER", nullable: false),
                NombreTipo = table.Column<string>(type: "TEXT", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_TipoProducto", x => x.Id_Tipo);
                table.ForeignKey(
                    name: "FK_TipoProducto_Proveedor_Id_Tipo",
                    column: x => x.Id_Tipo,
                    principalTable: "Proveedor",
                    principalColumn: "Id_Proveedor",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "Producto",
            columns: table => new
            {
                Id_Producto = table.Column<int>(type: "INTEGER", nullable: false),
                NombreProducto = table.Column<string>(type: "TEXT", nullable: false),
                PrecioCompra = table.Column<double>(type: "REAL", nullable: false),
                PrecioVenta = table.Column<double>(type: "REAL", nullable: false),
                TipoVenta = table.Column<string>(type: "TEXT", nullable: false),
                Existencia = table.Column<int>(type: "INTEGER", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Producto", x => x.Id_Producto);
                table.ForeignKey(
                    name: "FK_Producto_Pedido_Id_Producto",
                    column: x => x.Id_Producto,
                    principalTable: "Pedido",
                    principalColumn: "Id_Pedido",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_Producto_TipoProducto_Id_Producto",
                    column: x => x.Id_Producto,
                    principalTable: "TipoProducto",
                    principalColumn: "Id_Tipo",
                    onDelete: ReferentialAction.Cascade);
            });
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Admin");

        migrationBuilder.DropTable(
            name: "Cliente");

        migrationBuilder.DropTable(
            name: "Producto");

        migrationBuilder.DropTable(
            name: "Pedido");

        migrationBuilder.DropTable(
            name: "TipoProducto");

        migrationBuilder.DropTable(
            name: "Transferencia");

        migrationBuilder.DropTable(
            name: "Proveedor");

        migrationBuilder.DropTable(
            name: "Entrada");
    }
}
