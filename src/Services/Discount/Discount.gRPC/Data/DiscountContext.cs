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
            new Coupon { Id = 1, ProductName = "Iphone 15", Description = "Best iphone", Amount = 800 },
            new Coupon { Id = 2, ProductName = "Iphone 16", Description = "Best iphone", Amount = 1200 }
            );
    }
}
