using Discount.gRPC.Models;
using Microsoft.EntityFrameworkCore;

namespace Discount.gRPC.Data;

public class DiscountContext : DbContext
{
    public DbSet<Coupon> Coupones { get; set; }

    public DiscountContext(DbContextOptions<DiscountContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Coupon>().HasData(
            new Coupon { Id = 1, ProductName = "Iphone X", Description = "Iphone X coupon", Amount = 500 },
            new Coupon { Id = 2, ProductName = "Iphone 11", Description = "Iphone 11 coupon", Amount = 650 },
            new Coupon { Id = 3, ProductName = "Iphone 12", Description = "Iphone 12 coupon", Amount = 700 },
            new Coupon { Id = 4, ProductName = "Iphone 13", Description = "Iphone 13 coupon", Amount = 750 },
            new Coupon { Id = 5, ProductName = "Iphone 14", Description = "Iphone 14 coupon", Amount = 800 },
            new Coupon { Id = 6, ProductName = "Iphone 15", Description = "Best iphone", Amount = 1000 },
            new Coupon { Id = 7, ProductName = "Iphone 16", Description = "Best iphone", Amount = 1200 }
            );
    }
}
