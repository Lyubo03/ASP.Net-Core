namespace FDMC.App.Controllers
{
    using FDMC.App.Data;
    using FDMC.App.Models;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Linq;

    public class CatController : Controller
    {
        private readonly FDMCDbContext context;

        public CatController(FDMCDbContext context)
        {
            this.context = context;
        }

        public IActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Add(CatBindingModel model)
        {
            var cat = new Cat
            {
                Name = model.Name,
                Age = model.Age,
                Breed = model.Breed,
                ImageUrl = model.ImageUrl
            };

            context.Cats.Add(cat);
            context.SaveChanges();

            return this.Redirect("/Home/Index");
        }
        public IActionResult Details(string id)
        {
            var cat = context.Cats.SingleOrDefault(c => c.Id == id);

            var catModel = new CatDetailsModel
            {
                Name = cat.Name,
                Age = cat.Age,
                Breed = cat.Breed,
                ImageUrl = cat.ImageUrl
            };

            if (cat == null)
            {
                return this.NotFound();
            }

            return this.View(catModel);
        }
    }
}