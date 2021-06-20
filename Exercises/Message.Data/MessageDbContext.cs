namespace Message.Data
{
    using Microsoft.EntityFrameworkCore;

    using Domain;
    public class MessageDbContext : DbContext
    {
        public MessageDbContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Message> Messages { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options
                    .UseSqlServer("Server=DESKTOP-2RO7KG1\\SQLEXPRESS;Database=Message;Trusted_Connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder model)
        {
            base.OnModelCreating(model);
        }

    }
}