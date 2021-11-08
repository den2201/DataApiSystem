using CustomerService.Domain.Model;
using CustomerService.Dto;
using CustomerService.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerService.Controllers
{
    [ApiController]
    [Route("/api/customer")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet]
        [Route("GetCustomers")]
        public async Task<IEnumerable<Customer>> GetAllProducts()
        {
            return await _customerRepository.GetAllCustomers();
        }

        [HttpGet]
        [Route("GetByName")]
        public async Task<IEnumerable<Customer>> GetProductsByName([FromQuery] string name)
        {
            return await _customerRepository.GetByNameAsync(name);
        }

        [HttpPost]
        [Route("Add")]

        public async Task AddProduct([FromBody] CustomerDto customer)
        {
            await _customerRepository.AddCustomer(customer);
        }

        [HttpPut]
        [Route("update")]

        public async Task UpdateProduct([FromBody] Customer product)
        {
            await _customerRepository.UpdateCustomerAsync(product);
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task DeleteProduct(Guid id)
        {
            await _customerRepository.DeleteCustomerAsync(id);
        }
    }
}
