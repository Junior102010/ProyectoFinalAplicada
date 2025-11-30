using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoFinalAplicada1.Migrations
{
    /// <inheritdoc />
    public partial class Cliente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContrasenaCliente",
                table: "Cliente");

            migrationBuilder.AlterColumn<int>(
                name: "CategoriaId",
                table: "Categoria",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddForeignKey(
                name: "FK_Categoria_Proveedor_CategoriaId",
                table: "Categoria",
                column: "CategoriaId",
                principalTable: "Proveedor",
                principalColumn: "ProveedorId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categoria_Proveedor_CategoriaId",
                table: "Categoria");

            migrationBuilder.AddColumn<string>(
                name: "ContrasenaCliente",
                table: "Cliente",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "CategoriaId",
                table: "Categoria",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);
        }
    }
}
