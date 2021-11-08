using ProductService.Domain;
using ProductService.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductService.Repository
{
    public interface IRepository
    {
        public Task<Product> GetByIdAsync(Guid id);
        public Task<IEnumerable<Product>> GetAllProducts();
        public Task<IEnumerable< Product>> GetByNameAsync(string name);
        public Task AddProduct(ProductDto product);
        public Task UpdateProductAsync(Product product);
        public Task DeleteProductAsync(Guid id);
    }
}
