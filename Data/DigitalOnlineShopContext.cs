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
                
                yield return new Product { Id = 3, Name = "Vivobook r655",CategoryId = 1, Price = 3000.02m};
                // ... add more Products ...
            }
        }

    public static class CategorySeedData
            {
                public static IEnumerable<Category> GetProducts()
                {
                    
                    yield return new Category { Id = 1, Name = "Laptop"};
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

       /* modelBuilder.Entity<Product>().HasMany(p => p.FieldValues)
        .WithOne().OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Category>().HasMany(p => p.Fields)
        .WithOne().OnDelete(DeleteBehavior.Cascade);
        
        modelBuilder.Entity<Category>().HasMany(p => p.Products)
        .WithOne().OnDelete(DeleteBehavior.Cascade); */

    // Configure the relationship between Field and Category


          modelBuilder.Entity<Product>()
         .HasMany(p => p.FieldValues)
         .WithOne(f => f.Product)
         .HasForeignKey(f=>f.ProductId);

          modelBuilder.Entity<Category>()
         .HasMany(c => c.Products)
         .WithOne(p => p.Category)
         .HasForeignKey(p=>p.CategoryId);

         modelBuilder.Entity<Field>()
        .HasOne(f => f.Category)
        .WithMany(c => c.Fields)  // Assuming Category has a collection of Fields
        .HasForeignKey(f => f.CategoryId);

    // Additional configurations...

    base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().HasData(ProductSeedData.GetProducts());

    }
    

        public DbSet<MvcMovie.Models.Product> Product { get; set; } = default!;
        public DbSet<MvcMovie.Models.Category> Category { get; set; } = default!;

        
    }


}
