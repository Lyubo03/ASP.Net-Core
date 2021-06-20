namespace Panda.App.Controllers
{
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;

    using Models.Package;
    using Panda.Services.Package;

    public class HomeController : Controller
    {
        private readonly IPackageService packageService;

        public HomeController( IPackageService packageService)
        {
            this.packageService = packageService;
        }

        public IActionResult Index()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                List<PackageHomeViewModel> userPackages = packageService
                    .GetPackagesWithRecipientsAndStatus()
                    .Where(r => r.Recipient.UserName == this.User.Identity.Name)
                    .Select(pack => new PackageHomeViewModel
                    {
                        Id = pack.Id,
                        Descritpiton = pack.Description,
                        Status = pack.Status.Name
                    })
                    .ToList();

                return this.View(userPackages);
            }

            return this.View();
        }
    }
}