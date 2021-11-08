using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductService.Domain;
using ProductService.Dto;
using ProductService.Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class ProductController : ControllerBase
    {
        IRepository _productRepository;

        public ProductController(IRepository repository)
        {
            _productRepository = repository;
        }

        [HttpGet]
        [Route("GetProducts")]
        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _productRepository.GetAllProducts();
        }
        
        [HttpGet]
        [Route("GetByName")]
        public async Task<IEnumerable<Product>> GetProductsByName([FromQuery] string name)
        {
           return await _productRepository.GetByNameAsync(name);
        }

        [HttpPost]
        [Route("Add")]
        
        public async Task AddProduct([FromBody]ProductDto product)
        {
            await _productRepository.AddProduct(product);
        }

        [HttpPut]
        [Route("update")]

        public async Task UpdateProduct([FromBody] Product product)
        {
            await _productRepository.UpdateProductAsync(product);
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task DeleteProduct(Guid id)
        {
            await _productRepository.DeleteProductAsync(id);
        }


    }
}
