namespace Panda.Services.Package
{
    using Domain;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IPackageService
    {
        Package GetById(string id);
        IQueryable<Package> GetPackagesWithRecipientsAndStatus();
        void AddPackage(Package package);
        void UpdatePackage(Package package);
        PackageStatus GetPackageStatus(string status);
    }
}