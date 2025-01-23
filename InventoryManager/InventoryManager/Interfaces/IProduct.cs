using InventoryManager.DTOs;
using InventoryManager.Models;
using System.Linq.Expressions;

namespace InventoryManager.Interfaces
{
    public interface IProduct
    {
        Task<IEnumerable<Product>> GetProductsAsync();
        Task<Product> GetProductByIdAsync(int productId);
        Task CreateProductAsync(Product productDTO);
        Task UpdateProductAsync(Product productDTO);
        Task DeleteProductAsync(int productId);
        Task<Product> GetByAsync(Expression<Func<Product, bool>> predicate);
    }
}
