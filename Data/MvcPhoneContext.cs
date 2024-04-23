using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Models;
using System.Linq;
namespace MvcPhone.Data
{

    
      public static class PhoneSeedData
        {
            public static IEnumerable<Phone> GetPhones()
            {
                yield return new Phone { Id = 10,Name = "iPhone 14 Pro Max",Color = "Silver", Price = 1099.01m, ImageUrl = "data:image/jpeg;base64,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"};
                yield return new Phone { Id = 11, Name = "Samsung Galaxy S23 Ultra",Color = "Lavender", Price = 1188.02m};
                // ... add more phones ...
            }
        }
    public class MvcPhoneContext : DbContext
    {
        public MvcPhoneContext (DbContextOptions<MvcPhoneContext> options)
            : base(options)
        {
        }

protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Phone>()
            .Property(p => p.Price)
            .HasConversion(new Decimal18Converter());

            modelBuilder.Entity<Phone>().HasData(PhoneSeedData.GetPhones());

    }
    


        public DbSet<MvcMovie.Models.Phone> Phone { get; set; } = default!;

        
    }


}
