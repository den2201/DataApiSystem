using CustomerService.Domain.Model;
using CustomerService.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerService.Repository
{
    public interface ICustomerRepository
    {
        public Task<Customer> GetByIdAsync(Guid id);
        public Task<IEnumerable<Customer>> GetAllCustomers();
        public Task<IEnumerable<Customer>> GetByNameAsync(string name);
        public Task AddCustomer(CustomerDto customer);
        public Task UpdateCustomerAsync(Customer customer);
        public Task DeleteCustomerAsync(Guid id);
    }
}
