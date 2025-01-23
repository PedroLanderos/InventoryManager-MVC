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
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categorias { get; set; }
        public DbSet<Provider> Proveedores { get; set; }
        public DbSet<LogInventory> LogsInventario { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Categoria)
                .WithMany(c => c.Productos)
                .HasForeignKey(p => p.CategoriaId);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Proveedor)
                .WithMany(pv => pv.Productos)
                .HasForeignKey(p => p.ProveedorId);

            modelBuilder.Entity<LogInventory>()
                .HasOne(l => l.Producto)
                .WithMany()
                .HasForeignKey(l => l.ProductoId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
