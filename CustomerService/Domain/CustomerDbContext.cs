using CustomerService.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace CustomerService.Domain
{
    public class CustomerDbContext : DbContext
    {
       public DbSet<Customer> Customers { get; set; }
        public CustomerDbContext(DbContextOptions<CustomerDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                Id = new Guid("71632E99-2F6C-4472-81A5-43C56E11637C"),
                Name = "Creed",
                Address = "Los-Angeles, 44",
                Phone = "999-111-45-67"
            });
        }
    }
}
