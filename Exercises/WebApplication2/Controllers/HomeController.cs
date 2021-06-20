namespace WebApplication2.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Diagnostics;
    using WebApplication2.Models;

    public class HomeController : Controller
    {

        public IActionResult BlogArticle(int year, int month, int day, string slug)
        {
            return this.Json(new[] { "I am Lyuboslav", "I'm Learning ASP.NET Core MVC" });
        }

        public IActionResult Index()
        {
            return View();
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