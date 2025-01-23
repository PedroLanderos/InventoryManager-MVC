using InventoryManager.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InventoryManager.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Product> Productos { get; set; }
        public DbSet<Category> Categorias { get; set; }
        public DbSet<Provider> Proveedores { get; set; }
        public DbSet<LogInventory> LogsInventario { get; set; }
    }
}
