using InventoryManager.DTOs;
using InventoryManager.Models;
using System.Linq.Expressions;

namespace InventoryManager.Interfaces
{
    public interface IProduct
    {
        Task<IEnumerable<Product>> GetProductsAsync();
        Task<Product> GetProductByIdAsync(int productId);
        Task CreateProductAsync(Product product);
        Task UpdateProductAsync(Product product);
        Task DeleteProductAsync(int productId);
        Task<IEnumerable<Product>> GetByAsync(Expression<Func<Product, bool>> predicate);
    }
}
