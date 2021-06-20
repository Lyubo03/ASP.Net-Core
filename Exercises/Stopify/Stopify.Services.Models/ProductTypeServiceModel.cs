namespace Stopify.Services.Models
{
    using Stopify.Data.Models;
    using Stopify.Services.Mapping;
    public class ProductTypeServiceModel : IMapFrom<ProductType>, IMapTo<ProductType>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}