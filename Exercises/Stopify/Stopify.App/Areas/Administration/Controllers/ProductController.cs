namespace Stopify.App.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Stopify.Services;
    using Stopify.Services.Models;
    using Stopify.Web.InputModels;
    using Stopify.Web.ViewModels;
    using System.Linq;
    using System.Threading.Tasks;

    public class ProductController : AdminController
    {
        private readonly IProductService productService;
        private readonly ICloudinaryService cloudinaryService;

        public ProductController(IProductService productService,
            ICloudinaryService cloudinaryService)
        {
            this.productService = productService;
            this.cloudinaryService = cloudinaryService;
        }

        [HttpGet("/Administration/Product/Type/Create")]
        public async Task<IActionResult> CreateType()
        {
            return this.View("Type/Create");
        }

        [HttpPost("/Administration/Product/Type/Create")]
        public async Task<IActionResult> CreateType(ProductTypeCreateInputModel createModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(createModel);
            }

            var productTypeServiceModel = new ProductTypeServiceModel
            {
                Name = createModel.Name
            };

            await productService.CreateProductType(productTypeServiceModel);

            return this.Redirect("/");
        }

        [HttpGet(Name = "Create")]
        public async Task<IActionResult> Create()
        {
            var productTypes = await productService.GetAllProductTypes().ToListAsync();

            var viewModelProductTypes = productTypes.Select(p =>
            new ProductCreateProductTypeViewModel
            {
                Name = p.Name
            })
            .ToList();

            ViewData["types"] = viewModelProductTypes;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateInputModel createModel)
        {
            if (!this.ModelState.IsValid)
            {
                var allProductTypes = await this.productService.GetAllProductTypes().ToListAsync();
                this.ViewData["types"] = allProductTypes.Select(productType => new
                ProductCreateProductTypeViewModel
                {
                    Name = productType.Name
                }).ToList();

                return this.View();
            }

            var pictureUrl = await this.cloudinaryService.UploadPictureAsync(
                createModel.Picture,
                createModel.Name);

            var productModel = AutoMapper.Mapper.Map<ProductServiceModel>(createModel);
            productModel.Picture = pictureUrl;

            await productService.Create(productModel);

            return this.Redirect("/");
        }
    }
}