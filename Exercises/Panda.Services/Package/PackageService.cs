namespace Panda.Services.Package
{
    using Microsoft.EntityFrameworkCore;
    using Panda.Data;
    using Panda.Domain;
    using System.Linq;
    using System.Threading.Tasks;

    public class PackageService : IPackageService
    {
        private readonly PandaDbContext context;

        public PackageService(PandaDbContext context)
        {
            this.context = context;
        }

        public void AddPackage(Package package)
        {
            context.Packages.AddAsync(package);
            context.SaveChanges();
        }

        public Package GetById(string id)
        {
            var package = context.Packages
                .Include(x => x.Receipt)
                .Include(x => x.Recipient)
                .SingleOrDefault(x => x.Id == id);

            return package;
        }

        public PackageStatus GetPackageStatus(string status) =>
                 context.PackageStatuses
                .SingleOrDefault(x => x.Name == status);

        public IQueryable<Package> GetPackagesWithRecipientsAndStatus()
        {
            IQueryable<Package> packages = context
                .Packages
                .Include(x => x.Receipt)
                .Include(x => x.Recipient);

            return packages;
        }
        public void UpdatePackage(Package package)
        {
            context.Packages.Update(package);
            context.SaveChangesAsync();
        }

    }
}