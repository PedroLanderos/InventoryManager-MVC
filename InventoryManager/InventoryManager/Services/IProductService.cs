using InventoryManager.Models;
using System.Linq.Expressions;

namespace InventoryManager.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(int productId);
        Task AddProductAsync(Product product);
        Task UpdateProductAsync(Product product);
        Task DeleteProductAsync(int productId);
        Task<IEnumerable<Product>> GetProductsByCriteriaAsync(Expression<Func<Product, bool>> predicate);
    }
}
