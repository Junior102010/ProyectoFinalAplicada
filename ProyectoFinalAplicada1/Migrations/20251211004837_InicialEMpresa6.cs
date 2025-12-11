using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoFinalAplicada1.Migrations
{
    /// <inheritdoc />
    public partial class InicialEMpresa6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<string>(
                name: "MetodoPago",
                table: "Pedido",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Sector",
                columns: table => new
                {
                    SectorId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false),
                    Municipio = table.Column<string>(type: "TEXT", nullable: false),
                    PrecioEnvio = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sector", x => x.SectorId);
                });

            migrationBuilder.CreateTable(
                name: "UnidadMedida",
                columns: table => new
                {
                    UnidadId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: false),
                    Abreviatura = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnidadMedida", x => x.UnidadId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sector");

            migrationBuilder.DropTable(
                name: "UnidadMedida");

            migrationBuilder.DropColumn(
                name: "MetodoPago",
                table: "Pedido");

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
                    Activa = table.Column<bool>(type: "INTEGER", nullable: false),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false)
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
                    ProductoId = table.Column<int>(type: "INTEGER", nullable: false),
                    ListaPrecioId = table.Column<int>(type: "INTEGER", nullable: false),
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
                name: "IX_ListaPrecioDetalle_ListaPrecioId",
                table: "ListaPrecioDetalle",
                column: "ListaPrecioId");

            migrationBuilder.CreateIndex(
                name: "IX_ListaPrecioDetalle_ProductoId",
                table: "ListaPrecioDetalle",
                column: "ProductoId");
        }
    }
}
