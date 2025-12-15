using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoFinalAplicada1.Migrations
{
    /// <inheritdoc />
    public partial class Proveedor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categoria_Proveedor_CategoriaId",
                table: "Categoria");

            migrationBuilder.AddColumn<string>(
                name: "DiasEntrega",
                table: "Proveedor",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Direccion",
                table: "Proveedor",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Proveedor",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaRegistro",
                table: "Proveedor",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "RNC",
                table: "Proveedor",
                type: "TEXT",
                maxLength: 11,
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiasEntrega",
                table: "Proveedor");

            migrationBuilder.DropColumn(
                name: "Direccion",
                table: "Proveedor");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Proveedor");

            migrationBuilder.DropColumn(
                name: "FechaRegistro",
                table: "Proveedor");

            migrationBuilder.DropColumn(
                name: "RNC",
                table: "Proveedor");

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
    }
}
