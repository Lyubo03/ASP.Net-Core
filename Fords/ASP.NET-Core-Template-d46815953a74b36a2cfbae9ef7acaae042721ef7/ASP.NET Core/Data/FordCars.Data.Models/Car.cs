namespace FordCars.Data.Models
{
    using FordCars.Data.Common.Models;

    public class Car : BaseDeletableModel<int>
    {
        public string Title { get; set; }
        public ushort Year { get; set; }
        public byte Month { get; set; }
        public string Description { get; set; }
        public int CarModelId { get; set; }
        public virtual CarModel CarModel { get; set; }

    }
}