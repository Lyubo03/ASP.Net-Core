namespace Stopify.App.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Stopify.Services;
    using Stopify.Web.ViewModels.Home.Index;
    using System.Linq;
    using System.Threading.Tasks;

    public class HomeController : Controller
    {
        private readonly IProductService productService;

        public HomeController(IProductService productService)
        {
            this.productService = productService;
        }
        public async  Task<IActionResult> Index()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                var products = await this.productService.GetAllProducts().Select(product => new
                ProductHomeViewModel
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    Picture = product.Picture
                }).ToListAsync();


                return this.View(products);
            }

            return this.View();
        }
    }
}