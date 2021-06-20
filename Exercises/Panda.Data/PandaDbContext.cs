namespace Panda.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Panda.Domain;

    public class PandaDbContext : IdentityDbContext<PandaUser, PandaUserRole, string>
    {
        public PandaDbContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Package> Packages { get; set; }
        public DbSet<Receipt> Receipts{ get; set; }
        public DbSet<PackageStatus> PackageStatuses { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<PandaUser>(user =>
            {
                user.HasKey(u => u.Id );


                user
                .HasMany(p => p.Packages)
                .WithOne(r => r.Recipient);

                user
                .HasMany(p => p.Receipts)
                .WithOne(r => r.Recipient);
            });

            builder.Entity<Package>(pack =>
            {

                pack
                .HasOne(r => r.Receipt)
                .WithOne(p => p.Package)
                .HasForeignKey<Receipt>(p => p.PackageId)
                .OnDelete(DeleteBehavior.Restrict);

            });

            base.OnModelCreating(builder);
        }
    }
}