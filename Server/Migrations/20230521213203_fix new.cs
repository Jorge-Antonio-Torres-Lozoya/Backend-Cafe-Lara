using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Act17.Server.Migrations
{
    /// <inheritdoc />
    public partial class fixnew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Ventas",
                newName: "VentaId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Productos",
                newName: "ProductoId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Clientes",
                newName: "ClienteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VentaId",
                table: "Ventas",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ProductoId",
                table: "Productos",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ClienteId",
                table: "Clientes",
                newName: "Id");
        }
    }
}
