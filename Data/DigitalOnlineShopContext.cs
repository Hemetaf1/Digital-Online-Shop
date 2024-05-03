using Microsoft.EntityFrameworkCore;
using MvcMovie.Models; // Assuming Product and Category classes are in this namespace
using System.Collections.Generic;

namespace DigitalOnlineShop.Data
{
    public static class SeedData
    {
        public static IEnumerable<Product> GetProducts()
        {
            yield return new Product { Id = 3, Name = "Vivobook r655", CategoryId = 1, Price = 3000.02m };
            // Add more Products as needed
        }

        public static IEnumerable<Category> GetCategories()
        {
            yield return new Category { Id = 1, Name = "Laptop" };
            // Add more Categories as needed
        }
    }

    public class DigitalOnlineShopContext : DbContext
    {
        public DigitalOnlineShopContext(DbContextOptions<DigitalOnlineShopContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure Price property conversion
            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasConversion<decimal>();

            // Seed initial data
            modelBuilder.Entity<Product>().HasData(SeedData.GetProducts());
            modelBuilder.Entity<Category>().HasData(SeedData.GetCategories());

            // Additional configurations...
        }
    }
}
