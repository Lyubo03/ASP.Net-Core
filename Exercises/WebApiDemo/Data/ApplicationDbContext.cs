namespace WebApiDemo.Data
{
    using Microsoft.EntityFrameworkCore;
    using WebApiDemo.Models;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {

        }

        public ApplicationDbContext(DbContextOptions options)
            :base(options)
        {

        }
        public DbSet<Car> Cars { get; set;}
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer(@"Server=DESKTOP-2RO7KG1\SQLEXPRESS;Database=Cars;Integrated Security=true;");
            }
        }
    }
}