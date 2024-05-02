using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Models;
using System.Linq;
namespace DigitalOnlineShop.Data
{

    
      public static class ProductSeedData
        {
            public static IEnumerable<Product> GetProducts()
            {
                
                yield return new Product { Id = 3, Name = "Vivobook r655", Price = 3000.02m};
                // ... add more Products ...
            }
        }
        
    public class DigitalOnlineShopContext : DbContext
    {
        public DigitalOnlineShopContext (DbContextOptions<DigitalOnlineShopContext> options)
            : base(options)
        {
        }

protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>()
            .Property(p => p.Price)
            .HasConversion(new Decimal18Converter());

            modelBuilder.Entity<Product>().HasData(ProductSeedData.GetProducts());

    }
    

        public DbSet<MvcMovie.Models.Product> Product { get; set; } = default!;
        public DbSet<MvcMovie.Models.Category> Category { get; set; } = default!;

        
    }


}
