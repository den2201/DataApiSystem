using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace ProductService.Domain
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = new Guid("716C2E99-6F6C-4472-81A5-43C56E11637C"),
                Name = "Milk",
                Description = "Milk 3%",
                Price = 3.56F
            },
            new Product
            {
                Id = new Guid("716C7E99-6F2C-4472-81A5-43C56E31637A"),
                Name = "Bread",
                Description = "Dark bread",
                Price = 1.46F
            });
        }
    }
}
