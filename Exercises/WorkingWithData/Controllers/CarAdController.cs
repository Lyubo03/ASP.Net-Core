namespace WorkingWithData.Controllers
{
    using System;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;
    using WorkingWithData.Models.CarAd;

    public class CarAdController : Controller
    {
        public IActionResult Create()
        {
            var model = new CreateInputModel();
            
            model.ReleaseDate = DateTime.UtcNow;
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(CreateInputModel input)
        {
            if (!ModelState.IsValid)
            {
                return this.View(input);
            }
            return this.Json(input);

        }
    }
}