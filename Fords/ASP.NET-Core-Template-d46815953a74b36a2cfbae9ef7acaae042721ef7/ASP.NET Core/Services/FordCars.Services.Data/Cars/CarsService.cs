namespace FordCars.Services.Data.Cars
{
    using FordCars.Data;
    using System.Collections.Generic;
    using System.Linq;
    using FordCars.Services.Mapping;
    using FordCars.Data.Models;
    using FordCars.Data.Common.Repositories;

    public class CarsService : ICarsService
    {
        private readonly IDeletableEntityRepository<Car> carsRepository;

        public CarsService(IDeletableEntityRepository<Car> carsRepository)
        {
            this.carsRepository = carsRepository;
        }
        public IEnumerable<TViewModel> GetTopCars<TViewModel>(int count = 5)
        {
            var cars = this.carsRepository.All()
                .OrderByDescending(x => x.CreatedOn)
                .To<TViewModel>()
                .Take(count)
                .ToList();

            return cars;
        }
    }
}