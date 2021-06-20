using Microsoft.AspNetCore.Mvc;
using RazorLection.Models;
using RazorLection.Models.Home;
using RazorLection.Services;
using System.Diagnostics;

namespace RazorLection.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService service;
        public HomeController(IUserService service)
        {
            this.service = service;
        }
        public IActionResult Index()
        {
            var usernames = service.GetUsernames();

            var viewModel = new IndexViewModel { Usernames = usernames};

            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}