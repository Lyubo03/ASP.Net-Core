namespace Stopify.Data
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Stopify.Data.Models;

    public class StopifyDbContext : IdentityDbContext<StopifyUser, IdentityRole, string>
    {
        public StopifyDbContext(DbContextOptions options)
            :base(options)
        {

        }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Receipt> Receipts { get; set; }

        public DbSet<OrderStatus> OrderStatuses { get; set; }
    }
}