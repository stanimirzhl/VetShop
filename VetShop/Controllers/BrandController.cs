using Microsoft.AspNetCore.Mvc;
using VetShop.Core;
using VetShop.Core.Interfaces;
using VetShop.Core.Models;
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

        public IActionResult Add()
        {
            var brandForm = new BrandFormModel()
            {

            };
            return View(brandForm);
        }
        [HttpPost]
        public async Task<IActionResult> Add(BrandFormModel formModel)
        {
            if (!ModelState.IsValid)
            {
                return View(formModel);
            }

            var brandServiceModel = new BrandServiceModel
            {
                Name = formModel.BrandName,
                ImageUrl = formModel.ImageUrl
            };

            await brandService.AddAsync(brandServiceModel);
            return RedirectToAction("All");
        }
    }
}
