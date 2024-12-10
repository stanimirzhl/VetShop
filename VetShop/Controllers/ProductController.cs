using Microsoft.AspNetCore.Mvc;
using VetShop.Core.Interfaces;
using VetShop.Models.Product;

namespace VetShop.Controllers
{
    public class ProductController : Controller
    {
        private IProductService productService;
        ILogger<ProductController> logger;
        private IBrandService brandService;

        public ProductController(IProductService productService, ILogger<ProductController> logger, IBrandService brandService)
        {
            this.productService = productService;
            this.logger = logger;
            this.brandService = brandService;
        }
        [HttpGet]
        public async Task<IActionResult> All(List<int>? brandIds, string? searchTerm, int pageNumber = 1, int pageSize = 8)
        {
            ViewData["SearchTerm"] = searchTerm;
            ViewData["BrandIds"] = brandIds;
            ViewData["Brands"] = await brandService.GetAllBrandsAsync();

            var pagedProducts = await productService.GetPagedProductsAsync(searchTerm, pageNumber, pageSize, brandIds);

            var pagedViewModels = pagedProducts.Map(p => new ProductViewModel()
            {
                Id = p.Id,
                Title = p.Title,
                Description = p.Description,
                Price = p.Price,
                ImageUrl = p.ImageUrl,
                CategoryId = p.CategoryId,
                BrandId = p.BrandId,
            });

            return View(pagedViewModels);

        }
    }
}
