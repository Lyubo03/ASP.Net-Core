namespace Panda.App.Controllers
{
    using System;
    using System.Linq;
    using System.Globalization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Authorization;


    using Models.Package;
    using Data;
    using Domain;
    using Services.Package;
    using Panda.Services.Receipt;
    using Panda.Services.User;

    public class PackageController : Controller
    {
        private readonly IPackageService packageService;
        private readonly IReceiptService receiptService;
        private readonly IUserService userService;

        public PackageController(IPackageService packageService,
            IReceiptService receiptService,
            IUserService userService)
        {
            this.packageService = packageService;
            this.receiptService = receiptService;
            this.userService = userService;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            this.ViewData["Recipients"] = userService.GetAllUsers().ToList();
            return this.View();
        }
        [HttpPost]
        public IActionResult Create(PackageCreateBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model ?? new PackageCreateBindingModel());

            }

            var package = new Package
            {
                Description = model.Description,
                Weight = model.Weight,
                ReceiptId = this.userService.GetAllUsers().Where(u => u.UserName == model.Recipient).Select(x => x.Id).FirstOrDefault(),
                Recipient = this.userService.GetAllUsers().Where(u => u.UserName == model.Recipient).FirstOrDefault(),
                ShippingAddress = model.ShippingAddress,
                Status = packageService.GetPackageStatus("Pending")
            };


            packageService.AddPackage(package);

            return this.View("/Package/Pending", package);
        }

        [HttpGet]
        public IActionResult Pending()
        {
            var packages = packageService.GetPackagesWithRecipientsAndStatus().ToList();

            return this.View(packages.Select(package =>
                {
                    return new PackagePendingViewModel
                    {
                        Id = package.Id,
                        Description = package.Description,
                        Weight = package.Weight,
                        ShippingAddress = package.ShippingAddress,
                        Recipient = package.Recipient.UserName
                    };
                }).ToList());
        }

        [HttpGet("Package/Ship/{Id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Ship(string id)
        {
            var package = packageService.GetById(id);

            package.Status =this.packageService.GetPackageStatus("Shipped");
            package.EstimatedDeliveryDate = DateTime.UtcNow.AddDays(new Random().Next(20, 40));
            packageService.UpdatePackage(package);

            return this.Redirect("/Package/Shipped");
        }

        [HttpGet("/Package/Details/{id}")]
        [Authorize]
        public IActionResult Details(string id)
        {
            var package = packageService.GetById(id);

            var viewModel = new PackageDetailsViewModel
            {
                Id = package.Id,
                Description = package.Description,
                Recipient = package.Recipient.UserName,
                Weight = package.Weight,
                ShippingAddress = package.ShippingAddress,
            };

            if (package.Status.Name == "Pending")
            {
                viewModel.Status = "Pending";
                viewModel.EstimatedDelivaryDate = "N/A";
            }

            else if (package.Status.Name == "Shipped")
            {
                viewModel.Status = "Shipped";
                viewModel.EstimatedDelivaryDate = package.EstimatedDeliveryDate?.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
            }

            else
            {
                viewModel.EstimatedDelivaryDate = "Delivered";
                viewModel.Status = "Delivered";
            }

            return this.View(viewModel);
        }

        [HttpGet("/Package/Deliver/{Id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Deliver(string id)
        {
            var package = packageService.GetById(id);
            package.Status = packageService.GetPackageStatus("Delivered");
            packageService.UpdatePackage(package);

            return this.Redirect("/Package/Delivered");
        }

        [HttpGet("/Package/Acquire/{Id}")]
        [Authorize]
        public IActionResult Acquire(string id)
        {
            var package = packageService.GetById(id);
            package.Status = packageService.GetPackageStatus("Acquired");

            var receipt = new Receipt
            {
                Fee = (decimal)(2.67 * package.Weight),
                Package = package,
                IssuedOn = DateTime.UtcNow,
                RecipientId = package.ReceiptId,
                Recipient = package.Recipient
            };

            receiptService.AddReceipt(receipt);
            packageService.UpdatePackage(package);

            return this.Redirect("/Home/Index");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]

        public IActionResult Delivered()
        {
            return this.View(packageService
                .GetPackagesWithRecipientsAndStatus()
                .Where(x => x.Status.Name == "Delivered" || x.Status.Name == "Acquired")
                .ToList().Select(pack =>
                {
                    return new PackageDeliveredViewModel
                    {
                        Id = pack.Id,
                        Description = pack.Description,
                        Recipient = pack.Recipient.UserName,
                        Weight = pack.Weight,
                        ShippingAddress = pack.ShippingAddress,
                    };
                }).ToList());
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]

        public IActionResult Shipped()
        {
            var packages = packageService
                .GetPackagesWithRecipientsAndStatus()
                .Where(x => x.Status.Name == "Shipped").ToList()
                .Select(pack =>
                {
                    return new PackageShippedViewModel
                    {
                        Id = pack.Id,
                        Description = pack.Description,
                        Recipient = pack.Recipient.UserName.ToString(),
                        Weight = pack.Weight,
                        EstimatedDeliveryDate = pack.EstimatedDeliveryDate?.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)
                    };
                }).ToList();

            return this.View(packages);
        }
    }
}