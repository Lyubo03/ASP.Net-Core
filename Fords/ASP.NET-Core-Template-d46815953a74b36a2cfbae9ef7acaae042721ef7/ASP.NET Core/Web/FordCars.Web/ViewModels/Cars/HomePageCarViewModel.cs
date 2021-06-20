namespace FordCars.Web.ViewModels.Cars
{
    using AutoMapper;
    using FordCars.Data.Models;
    using FordCars.Services.Mapping;

    public class HomePageCarViewModel : IMapFrom<Car>, IHaveCustomMappings
    {
        public string Title { get; set; }
        public string ModelName { get; set; }
        public string YearAndMonth{ get; set; }
        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
        }
    }
}