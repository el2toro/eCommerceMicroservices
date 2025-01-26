using Discount.gRPC.Models;
using Microsoft.EntityFrameworkCore;

namespace Discount.gRPC.Data;

public class DiscountContext : DbContext
{
    public DbSet<Coupon> Coupones { get; set; }

    public DiscountContext(DbContextOptions<DiscountContext> options) : base(options)
    {
    }
}
