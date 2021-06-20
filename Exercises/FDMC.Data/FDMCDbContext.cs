namespace FDMC.Data
{
    using FDMC.Models;
    using Microsoft.EntityFrameworkCore;

    public class FDMCDbContext : DbContext
    {
        public FDMCDbContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Cat> Cats { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}