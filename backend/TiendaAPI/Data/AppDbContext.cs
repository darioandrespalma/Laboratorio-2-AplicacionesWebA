using Microsoft.EntityFrameworkCore;
using TiendaAPI.Models;  // <--- ¡ESTA LÍNEA ES IMPORTANTE!

namespace TiendaAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<TipoProducto> TipoProductos { get; set; }
        public DbSet<Producto> Productos { get; set; }
    }
}