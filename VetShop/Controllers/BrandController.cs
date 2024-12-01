using Microsoft.AspNetCore.Mvc;
using VetShop.Core;
using VetShop.Core.Interfaces;
using VetShop.Models.Brand;

namespace VetShop.Controllers
{
    public class BrandController : Controller
    {
        private IBrandService brandService;
        ILogger<BrandController> logger;

        public BrandController(IBrandService brandService, ILogger<BrandController> logger)
        {
            this.brandService = brandService;
            this.logger = logger;
        }

        public async Task<IActionResult> All(string? searchTerm, int pageIndex = 1, int pageSize = 10)
        {
            ViewData["SearchTerm"] = searchTerm;
            var pagedBrands = await brandService.GetPagedBrandsAsync(searchTerm, pageIndex, pageSize);
            var pagedViewModels =
                pagedBrands.Map(b => new BrandViewModel
                {
                    Id = b.Id,
                    BrandName = b.Name,
                    ImageUrl = b.ImageUrl
                });

            return View(pagedViewModels);
        }

    }
}
