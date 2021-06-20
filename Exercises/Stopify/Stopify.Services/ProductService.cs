namespace Stopify.Services
{
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Stopify.Data;
    using Stopify.Data.Models;
    using Stopify.Services.Mapping;
    using Stopify.Services.Models;

    public class ProductService : IProductService
    {
        private readonly StopifyDbContext context;

        public ProductService(StopifyDbContext context)
        {
            this.context = context;
        }
        public async Task<bool> Create(ProductServiceModel createModel)
        {
            var productTypeFromDb = context.ProductTypes
                .SingleOrDefault(x => x.Name == createModel.ProductType.Name);

            var product = AutoMapper.Mapper.Map<Product>(createModel);
            product.ProductType = productTypeFromDb;

            await context.Products.AddAsync(product);
            var result = await context.SaveChangesAsync();

            return result > 0;
        }

        public async Task<bool> CreateProductType(ProductTypeServiceModel createModel)
        {
            var productType = new ProductType
            {
                Name = createModel.Name
            };

            await context.ProductTypes.AddAsync(productType);
            var result = await context.SaveChangesAsync();

            return result > 0;
        }

        public IQueryable<ProductServiceModel> GetAllProducts()
        {
            return this.context.Products.To<ProductServiceModel>();
        }

        public IQueryable<ProductTypeServiceModel> GetAllProductTypes()
        {
            return this.context.ProductTypes.To<ProductTypeServiceModel>();
        }

        public async Task<ProductServiceModel> GetByIdAsync(string id)
        {
            return await context.Products
                .To<ProductServiceModel>()
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}