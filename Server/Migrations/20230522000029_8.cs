using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Act17.Server.Migrations
{
    /// <inheritdoc />
    public partial class _8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Ventas_VentaId",
                table: "Productos");

            migrationBuilder.DropIndex(
                name: "IX_Productos_VentaId",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "VentaId",
                table: "Productos");

            migrationBuilder.CreateTable(
                name: "ProductoVenta",
                columns: table => new
                {
                    ProductosProductoId = table.Column<int>(type: "int", nullable: false),
                    VentasVentaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductoVenta", x => new { x.ProductosProductoId, x.VentasVentaId });
                    table.ForeignKey(
                        name: "FK_ProductoVenta_Productos_ProductosProductoId",
                        column: x => x.ProductosProductoId,
                        principalTable: "Productos",
                        principalColumn: "ProductoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductoVenta_Ventas_VentasVentaId",
                        column: x => x.VentasVentaId,
                        principalTable: "Ventas",
                        principalColumn: "VentaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductoVenta_VentasVentaId",
                table: "ProductoVenta",
                column: "VentasVentaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductoVenta");

            migrationBuilder.AddColumn<int>(
                name: "VentaId",
                table: "Productos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Productos_VentaId",
                table: "Productos",
                column: "VentaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Ventas_VentaId",
                table: "Productos",
                column: "VentaId",
                principalTable: "Ventas",
                principalColumn: "VentaId");
        }
    }
}
