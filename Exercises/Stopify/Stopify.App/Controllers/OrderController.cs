namespace Stopify.App.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Stopify.Services;
    using Stopify.Services.Mapping;
    using Stopify.Web.ViewModels.Order.Cart;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;

    public class OrderController : Controller
    {
        private readonly IOrderService orderService;
        private readonly IReceiptService receiptService;

        public OrderController(IOrderService orderService, IReceiptService receiptService)
        {
            this.orderService = orderService;
            this.receiptService = receiptService;
        }
        [HttpGet("Cart")]
        [Route("/Order/Cart")]
        public async Task<IActionResult> Cart()
        {
            var orders = await this.orderService.GetAll()
                .Where(x => x.Status.Name == "Active" &&
                x.IssuerId == this.User.FindFirst(ClaimTypes.NameIdentifier).Value)
                .To<OrderCartViewModel>()
                .ToListAsync();

            return this.View();
        }
        [HttpPost]
        [Route("/Order/Cart/Complete")]
        public async Task<IActionResult> Complete()
        {
            string userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var receiptId = await receiptService.CreateReceipt(userId);

            return this.Redirect($"/Receipt/Details/{receiptId}");
        }
        [HttpPost(Name = "Reduce")]
        [Route("/Order/{id}/Quantity/Reduce")]
        public async Task<IActionResult> Reduce(string id)
        {
            await orderService.ReduceQuantity(id);
            return this.Ok();
        }

        [HttpPost(Name = "Increase")]
        [Route("/Order/{id}/Quantity/Increase")]
        public async Task<IActionResult> Increase(string id)
        {
            await orderService.IncreaseQuantity(id);
            return this.Ok();
        }
    }
}