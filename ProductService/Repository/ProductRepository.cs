using Microsoft.EntityFrameworkCore;
using ProductService.Domain;
using ProductService.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.Repository
{
    public class ProductRepository : IRepository
    {
        private readonly ProductDbContext _dbContext;
        public ProductRepository(ProductDbContext context)
        {
            _dbContext = context;
        }
        public async Task AddProduct(ProductDto product)
        {
            try
            {
                await _dbContext.Products.AddAsync(new Product
                {
                    Id = new Guid(),
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                });
                await _dbContext.SaveChangesAsync();
              
            }
            catch (Exception ex)
            {
                throw new Exception($"Error product adding {ex.Message}");
            }
        }

        public async Task DeleteProductAsync(Guid id)
        {
                var product = await _dbContext.Products.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (product != null)
            {
                _dbContext.Products.Remove(product);
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Delete Error");
            }
           
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            var products = _dbContext.Products;
            if(products == null)
            {
                throw new Exception($"Error getting products");
            }
            return await products.ToListAsync();
        }

        public async Task<Product> GetByIdAsync(Guid id)
        {
            var product =  _dbContext.Products.Where(x => x.Id == id).FirstOrDefault();
            if (product == null)
            {
                new Product { Id = new Guid(), Name = String.Empty, Description = String.Empty, Price = 0 };
            }
            return product;
        }

        public async Task<IEnumerable<Product>> GetByNameAsync(string name)
        {
            var products = await _dbContext.Products.Where(x => x.Name == name).ToListAsync();
            if (products == null)
            {
                return null;
            }
            return products;
        }

        public async Task UpdateProductAsync(Product product)
        {
            _dbContext.Entry(product).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
