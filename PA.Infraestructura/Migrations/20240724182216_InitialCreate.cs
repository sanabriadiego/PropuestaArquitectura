using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PA.Infraestructura.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    IdCategoria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.IdCategoria);
                });

            migrationBuilder.CreateTable(
                name: "TiposProducto",
                columns: table => new
                {
                    IdTipoProducto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposProducto", x => x.IdTipoProducto);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    IdProducto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    FechaVencimiento = table.Column<DateOnly>(type: "date", nullable: false),
                    Observaciones = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: ""),
                    TipoProductoIdTipoProducto = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.IdProducto);
                    table.ForeignKey(
                        name: "FK_Productos_TiposProducto_TipoProductoIdTipoProducto",
                        column: x => x.TipoProductoIdTipoProducto,
                        principalTable: "TiposProducto",
                        principalColumn: "IdTipoProducto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CodigosBarras",
                columns: table => new
                {
                    IdCodigoBarra = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Activo = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    ProductoIdProducto = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CodigosBarras", x => x.IdCodigoBarra);
                    table.ForeignKey(
                        name: "FK_CodigosBarras_Productos_ProductoIdProducto",
                        column: x => x.ProductoIdProducto,
                        principalTable: "Productos",
                        principalColumn: "IdProducto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductosCategorias",
                columns: table => new
                {
                    IdDetalle = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductoIdProducto = table.Column<int>(type: "int", nullable: false),
                    CategoriaIdCategoria = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductosCategorias", x => x.IdDetalle);
                    table.ForeignKey(
                        name: "FK_ProductosCategorias_Categorias_CategoriaIdCategoria",
                        column: x => x.CategoriaIdCategoria,
                        principalTable: "Categorias",
                        principalColumn: "IdCategoria",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductosCategorias_Productos_ProductoIdProducto",
                        column: x => x.ProductoIdProducto,
                        principalTable: "Productos",
                        principalColumn: "IdProducto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CodigosBarras_ProductoIdProducto",
                table: "CodigosBarras",
                column: "ProductoIdProducto");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_TipoProductoIdTipoProducto",
                table: "Productos",
                column: "TipoProductoIdTipoProducto");

            migrationBuilder.CreateIndex(
                name: "IX_ProductosCategorias_CategoriaIdCategoria",
                table: "ProductosCategorias",
                column: "CategoriaIdCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_ProductosCategorias_ProductoIdProducto",
                table: "ProductosCategorias",
                column: "ProductoIdProducto");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CodigosBarras");

            migrationBuilder.DropTable(
                name: "ProductosCategorias");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "TiposProducto");
        }
    }
}
