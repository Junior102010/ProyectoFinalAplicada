using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoFinalAplicada1.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Abono",
                columns: table => new
                {
                    AbonoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClienteId = table.Column<int>(type: "INTEGER", nullable: false),
                    Monto = table.Column<double>(type: "REAL", nullable: false),
                    Observacion = table.Column<string>(type: "TEXT", nullable: false),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abono", x => x.AbonoId);
                    table.ForeignKey(
                        name: "FK_Abono_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CondicionPago",
                columns: table => new
                {
                    CondicionPagoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: false),
                    DiasCredito = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CondicionPago", x => x.CondicionPagoId);
                });

            migrationBuilder.CreateTable(
                name: "ListaPrecio",
                columns: table => new
                {
                    ListaPrecioId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false),
                    Activa = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListaPrecio", x => x.ListaPrecioId);
                });

            migrationBuilder.CreateTable(
                name: "TipoEmpresa",
                columns: table => new
                {
                    TipoEmpresaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoEmpresa", x => x.TipoEmpresaId);
                });

            migrationBuilder.CreateTable(
                name: "ZonaComercial",
                columns: table => new
                {
                    ZonaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NombreZona = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZonaComercial", x => x.ZonaId);
                });

            migrationBuilder.CreateTable(
                name: "ListaPrecioDetalle",
                columns: table => new
                {
                    DetalleId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ListaPrecioId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductoId = table.Column<int>(type: "INTEGER", nullable: false),
                    PrecioMayorista = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListaPrecioDetalle", x => x.DetalleId);
                    table.ForeignKey(
                        name: "FK_ListaPrecioDetalle_ListaPrecio_ListaPrecioId",
                        column: x => x.ListaPrecioId,
                        principalTable: "ListaPrecio",
                        principalColumn: "ListaPrecioId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ListaPrecioDetalle_Producto_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Producto",
                        principalColumn: "ProductoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Abono_ClienteId",
                table: "Abono",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_ListaPrecioDetalle_ListaPrecioId",
                table: "ListaPrecioDetalle",
                column: "ListaPrecioId");

            migrationBuilder.CreateIndex(
                name: "IX_ListaPrecioDetalle_ProductoId",
                table: "ListaPrecioDetalle",
                column: "ProductoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Abono");

            migrationBuilder.DropTable(
                name: "CondicionPago");

            migrationBuilder.DropTable(
                name: "ListaPrecioDetalle");

            migrationBuilder.DropTable(
                name: "TipoEmpresa");

            migrationBuilder.DropTable(
                name: "ZonaComercial");

            migrationBuilder.DropTable(
                name: "ListaPrecio");
        }
    }
}
