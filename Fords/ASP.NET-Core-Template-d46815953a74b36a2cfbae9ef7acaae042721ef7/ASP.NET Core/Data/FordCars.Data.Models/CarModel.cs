namespace FordCars.Data.Models
{
    using FordCars.Data.Common.Models;

    public class CarModel : BaseModel<int>
    {
        public string  Name{ get; set; }
    }
}