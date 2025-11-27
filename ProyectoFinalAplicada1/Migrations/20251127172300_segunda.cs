using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoFinalAplicada1.Migrations
{
    /// <inheritdoc />
    public partial class segunda : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Proveedor_Entrada_ProveedorId",
                table: "Proveedor");

            migrationBuilder.DropForeignKey(
                name: "FK_Transferencia_Admin_UsuarioId",
                table: "Transferencia");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TipoProducto",
                table: "TipoProducto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Admin",
                table: "Admin");

            migrationBuilder.RenameTable(
                name: "TipoProducto",
                newName: "Categoria");

            migrationBuilder.RenameTable(
                name: "Admin",
                newName: "Usuario");

            migrationBuilder.RenameColumn(
                name: "Referencia",
                table: "Entrada",
                newName: "Concepto");

            migrationBuilder.AlterColumn<int>(
                name: "ProveedorId",
                table: "Proveedor",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<int>(
                name: "ProveedorId",
                table: "Entrada",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categoria",
                table: "Categoria",
                column: "CategoriaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario",
                column: "UsuarioId");

            migrationBuilder.CreateTable(
                name: "EntradaDetalles",
                columns: table => new
                {
                    DetalleId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EntradaId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductoId = table.Column<int>(type: "INTEGER", nullable: false),
                    Cantidad = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntradaDetalles", x => x.DetalleId);
                    table.ForeignKey(
                        name: "FK_EntradaDetalles_Entrada_EntradaId",
                        column: x => x.EntradaId,
                        principalTable: "Entrada",
                        principalColumn: "EntradaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EntradaDetalles_Producto_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Producto",
                        principalColumn: "ProductoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EntradaDetalles_EntradaId",
                table: "EntradaDetalles",
                column: "EntradaId");

            migrationBuilder.CreateIndex(
                name: "IX_EntradaDetalles_ProductoId",
                table: "EntradaDetalles",
                column: "ProductoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transferencia_Usuario_UsuarioId",
                table: "Transferencia",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transferencia_Usuario_UsuarioId",
                table: "Transferencia");

            migrationBuilder.DropTable(
                name: "EntradaDetalles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categoria",
                table: "Categoria");

            migrationBuilder.DropColumn(
                name: "ProveedorId",
                table: "Entrada");

            migrationBuilder.RenameTable(
                name: "Usuario",
                newName: "Admin");

            migrationBuilder.RenameTable(
                name: "Categoria",
                newName: "TipoProducto");

            migrationBuilder.RenameColumn(
                name: "Concepto",
                table: "Entrada",
                newName: "Referencia");

            migrationBuilder.AlterColumn<int>(
                name: "ProveedorId",
                table: "Proveedor",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Admin",
                table: "Admin",
                column: "UsuarioId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TipoProducto",
                table: "TipoProducto",
                column: "CategoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Proveedor_Entrada_ProveedorId",
                table: "Proveedor",
                column: "ProveedorId",
                principalTable: "Entrada",
                principalColumn: "EntradaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transferencia_Admin_UsuarioId",
                table: "Transferencia",
                column: "UsuarioId",
                principalTable: "Admin",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
