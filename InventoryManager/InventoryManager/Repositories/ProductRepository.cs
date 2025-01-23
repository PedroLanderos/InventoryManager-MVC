using InventoryManager.Data;
using InventoryManager.Interfaces;
using InventoryManager.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;

namespace InventoryManager.Repositories
{
    public class ProductRepository : IProduct
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreateProductAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(int productId)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Product>> GetByAsync(Expression<Func<Product, bool>> predicate)
        {
            return await _context.Products
               .Include(p => p.Categoria)
               .Include(p => p.Proveedor)
               .Where(predicate)
               .ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int productId)
        {
            var product = await _context.Products
            .Include(p => p.Categoria) 
            .Include(p => p.Proveedor) 
            .FirstOrDefaultAsync(p => p.Id == productId); 
            if (product is null) return null!;
            else return product;
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _context.Products
                .Include(p => p.Categoria) // Carga la relación con Category
                .Include(p => p.Proveedor) // Carga la relación con Provider
                .ToListAsync();
        }

        public async Task UpdateProductAsync(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }
    }
}
