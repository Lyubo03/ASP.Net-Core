namespace Stopify.App.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Stopify.Services;
    using Stopify.Services.Mapping;
    using Stopify.Services.Models;
    using Stopify.Web.ViewModels.Receipt.Details;
    using Stopify.Web.ViewModels.Receipt.Profile;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;

    public class ReceiptController : Controller
    {
        private readonly IReceiptService receiptService;

        public ReceiptController(IReceiptService receiptService)
        {
            this.receiptService = receiptService;
        }
        [HttpGet(Name = "Profile")]
        public async Task<IActionResult> Profile()
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var receiptsFromDb = await this.receiptService
                .GetAllByRecipientId(userId)
                .ToListAsync();

            var receiptsForCurrentUser = receiptsFromDb
                .Select(receipt => receipt.To<ReceiptProfileViewModel>())
                .ToList();

            return this.View(receiptsForCurrentUser);
        }

        [HttpGet(Name = "Details")]
        public async Task<IActionResult> Details(string id)
        {
            var receiptServiceModel = await receiptService.GetAll()
                .SingleOrDefaultAsync(receipt => receipt.Id == id);

            var receiptDetailsViewModel = receiptServiceModel
                .To<ReceiptDetailsViewModel>();

            return this.View(receiptDetailsViewModel);
        }
    }
}