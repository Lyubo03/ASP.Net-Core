namespace FDMC.App.Data
{
    using FDMC.App.Models;
    using Microsoft.EntityFrameworkCore;

    public class FDMCDbContext : DbContext
    {
        public FDMCDbContext(DbContextOptions options)
            : base(options)
        {

        }
        public DbSet<Cat> Cats { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}