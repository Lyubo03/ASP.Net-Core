namespace FordCars.Web.Controllers
{
    using FordCars.Services.Data.Cars;
    using FordCars.Web.ViewModels.Cars;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : BaseController
    {
        private readonly ICarsService carsService;

        public HomeController(ICarsService carsService)
        {
            this.carsService = carsService;
        }
        public IActionResult Index()
        {
            var cars = this
                .carsService
                .GetTopCars<HomePageCarViewModel>(10);
            return this.View(cars);
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() => this.View();
    }
}
