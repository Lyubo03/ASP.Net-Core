namespace WebApiDemo.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using WebApiDemo.Data;
    using WebApiDemo.Models;

    public class CarsController : ApiController
    {
        private readonly ApplicationDbContext context;

        public CarsController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Car>> Get()
        {

            return this.context.Cars.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Car> Get(int id)
        {
            Car car = context.Cars.FirstOrDefault(c => c.Id == id);

            return car;
        }

        [HttpPost]
        public async Task<ActionResult<Car>> Post(Car car)
        {
            await this.context.Cars.AddAsync(car);
            await this.context.SaveChangesAsync();

            return this.CreatedAtAction("Get", new { id = car.Id});
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Car car, int id)
        {
            var dbCar = this.context.Cars.FirstOrDefault(x => x.Id == id);
            dbCar.Color = car.Color;
            dbCar.Model = car.Model;
            dbCar.Year = car.Year;

            await context.SaveChangesAsync();
            return this.NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Car>> Deletee(int id)
        {
            var car = this.context.Cars.FirstOrDefault(x => x.Id == id);
            this.context.Remove(car);
            await this.context.SaveChangesAsync();

            return car;
        }
    }
}