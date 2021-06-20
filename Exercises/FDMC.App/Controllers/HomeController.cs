using FDMC.App.Data;
using FDMC.App.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FDMC.App.Controllers
{
    public class HomeController : Controller
    {
        private readonly FDMCDbContext context;

        public HomeController(FDMCDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            List<CatDetailsModel> cats = context.Cats.Select(c => new CatDetailsModel 
            {
                Id = c.Id,
                Name = c.Name
            }).ToList();

            return View(cats);
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
