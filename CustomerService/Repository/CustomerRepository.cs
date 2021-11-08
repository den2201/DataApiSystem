using CustomerService.Domain;
using CustomerService.Domain.Model;
using CustomerService.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerService.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerDbContext _customerDbContext;
      public CustomerRepository(CustomerDbContext customerDbContext)
        {
            _customerDbContext = customerDbContext;
        }
        public async Task AddCustomer(CustomerDto customer)
        {
          await _customerDbContext.Customers.AddAsync( new Customer { Id = new Guid(), Name = customer.Name, Address = customer.Address, Phone=customer.Phone } );
          await _customerDbContext.SaveChangesAsync();
        }

        public async Task DeleteCustomerAsync(Guid id)
        {
            var customer = await _customerDbContext.Customers.FindAsync(new Customer { Id = id });
            if (customer != null)
                throw new ArgumentNullException("not found");
            _customerDbContext.Customers.Remove(customer);
            await _customerDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Customer>> GetAllCustomers()
        {
            return _customerDbContext.Customers;
        }

        public async Task<Customer> GetByIdAsync(Guid id)
        {
            return await _customerDbContext.Customers.FindAsync(new Customer { Id = id });
        }

        public async Task<IEnumerable<Customer>> GetByNameAsync(string name)
        {
            return await _customerDbContext.Customers.Where(x => x.Name == name).ToListAsync();
        }

        public async Task UpdateCustomerAsync(Customer customer)
        {
            _customerDbContext.Entry(customer).State = EntityState.Modified;
            await _customerDbContext.SaveChangesAsync();
        }
    }
}
