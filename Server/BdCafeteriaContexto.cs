using Act17.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Act17.Server
{
    public class BdCafeteriaContexto:DbContext
    {
        public BdCafeteriaContexto(DbContextOptions<BdCafeteriaContexto> options) : base(options)
        {

        }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<Producto>Productos { get; set; }

    }
}
