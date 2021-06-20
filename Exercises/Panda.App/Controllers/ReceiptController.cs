namespace Panda.App.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Panda.App.Models.Receipt;
    using Panda.Data;
    using Panda.Services.Receipt;
    using System.Globalization;
    using System.Linq;

    public class ReceiptController : Controller
    {
        private readonly IReceiptService receiptService;

        public ReceiptController(IReceiptService receiptService)
        {
            this.receiptService = receiptService;
        }

        [Authorize]
        public IActionResult My()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                var receipts = receiptService
                    .GetReceipts()
                    .Where(x => x.Recipient.UserName == User.Identity.Name)
                    .Select(receipt => new ReceiptMyViewModel
                    {
                        Id = receipt.Id,
                        Fee = receipt.Fee.ToString(),
                        IssuedOn = receipt.IssuedOn.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                        Recipient = receipt.Recipient.UserName
                    })
                    .ToList();

                return this.View(receipts);
            }

            return View();
        }
        [HttpGet("/Receipt/Details/{id}")]
        [Authorize]
        public IActionResult Details(string id)
        {
            var receipts = this.receiptService
                .GetReceipts()
                .Where(x => x.Id == id)
                .Select(r => new ReceiptDetailsViewModel
                {
                    Id = r.Id,
                    Total = r.Fee.ToString(),
                    DeliveryAddress = r.Package.ShippingAddress,
                    Description = r.Package.Description,
                    IssuedOn = r.IssuedOn.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                    Recipient = r.Recipient.UserName,
                    Weight = r.Package.Weight.ToString()
                }).SingleOrDefault();

            return this.View(receipts);
        }
    }
}