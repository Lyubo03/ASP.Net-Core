namespace FordCars.Services.Data.Cars
{
    using System.Collections.Generic;

    public interface ICarsService
    {
        IEnumerable<TViewModel> GetTopCars<TViewModel>(int count = 5);
    }
}