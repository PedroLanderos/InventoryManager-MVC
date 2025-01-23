using InventoryManager.Interfaces;
using InventoryManager.Models;
using InventoryManager.Repositories;
using System.Linq.Expressions;

namespace InventoryManager.Services
{
    public class ProductService : IProductService
    {
        private readonly IProduct _productRepository;

        public ProductService(IProduct productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task AddProductAsync(Product product)
        {
            if (product.Stock < 0)
                throw new ArgumentException("El stock no puede ser negativo.");
            if (product.Precio <= 0)
                throw new ArgumentException("El precio debe ser mayor a 0.");

            await _productRepository.CreateProductAsync(product);
        }

        public async Task DeleteProductAsync(int productId)
        {
            var existingProduct = await _productRepository.GetProductByIdAsync(productId);
            if (existingProduct == null)
                throw new KeyNotFoundException($"No se encontró un producto con el ID {productId}.");

            await _productRepository.DeleteProductAsync(productId);
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _productRepository.GetProductsAsync(); ;
        }

        public async Task<Product> GetProductByIdAsync(int productId)
        {
            var product = await _productRepository.GetProductByIdAsync(productId);
            if (product == null)
                throw new KeyNotFoundException($"No se encontró un producto con el ID {productId}.");
            return product;
        }

        public  async Task<IEnumerable<Product>> GetProductsByCriteriaAsync(Expression<Func<Product, bool>> predicate)
        {
            return await _productRepository.GetByAsync(predicate);
        }

        public async Task UpdateProductAsync(Product product)
        {
            var existingProduct = await _productRepository.GetProductByIdAsync(product.Id);
            if (existingProduct == null)
                throw new KeyNotFoundException($"No se encontró un producto con el ID {product.Id}.");

            await _productRepository.UpdateProductAsync(product);
        }
    }
}
