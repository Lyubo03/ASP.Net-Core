namespace Stopify.App.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Stopify.Services;
    using Stopify.Services.Mapping;
    using Stopify.Services.Models;
    using Stopify.Web.InputModels;
    using Stopify.Web.ViewModels.Product;
    using System.Security.Claims;
    using System.Threading.Tasks;

    [Authorize]
    public class ProductController : Controller
    {
        private readonly IProductService productService;
        private readonly IOrderService orderService;

        public ProductController(IProductService productService,
            IOrderService orderService)
        {
            this.productService = productService;
            this.orderService = orderService;
        }

        [HttpGet(Name = "Details")]
        public async Task<IActionResult> Details(string id)
        {
            ProductDetailsViewModel product = 
                (await productService.GetByIdAsync(id))
                .To<ProductDetailsViewModel>();
            
            return this.View(product);
        }
        [HttpPost(Name = "Order")]
        public async Task<IActionResult> Order(ProductOrderInputModel model)
        {
            var orderServiceModel = model.To<OrderServiceModel>();

            orderServiceModel.IssuerId = this.User
                .FindFirst(ClaimTypes.NameIdentifier).Value;

            await this.orderService.CreateOrder(orderServiceModel);

            return this.Redirect("/");
        }
    }
}