using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;
using VetShop.Core;
using VetShop.Core.Implementations;
using VetShop.Core.Interfaces;
using VetShop.Core.Models;
using VetShop.Infrastructure.Data.Models;
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
        [HttpGet]
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
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var brand = await brandService.GetByIdAsync(id);

                var model = new BrandDetailsViewModel
                {
                    BrandName = brand.Name,
                    ImageUrl = brand.ImageUrl
                };

                return View(model);
            }
            catch (NonExistentEntity ex)
            {
                logger.LogError(ex, "(GET)Not found request - Brand/Details");
                return NotFound();
            }

        }
        [HttpGet]
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
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var brand = await brandService.GetByIdAsync(id);

                var model = new BrandFormModel
                {
                    BrandName = brand.Name,
                    ImageUrl = brand.ImageUrl
                };

                return View(model);
            }
            catch (NonExistentEntity ex)
            {
                logger.LogError(ex, "(GET)Not found request - Brand/Edit");
                return NotFound();
            }

        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, BrandFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                var brand = await brandService.GetByIdAsync(id);
            }
            catch (NonExistentEntity ex)
            {
                logger.LogError(ex, "(Post)Not found request - Brand/Edit");
                return NotFound();
            }
            var brandServiceModel = new BrandServiceModel()
            {
                Id = id,
                Name = model.BrandName,
                ImageUrl= model.ImageUrl
            };

            await brandService.EditAsync(brandServiceModel);


            return RedirectToAction("All");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var brand = await brandService.GetByIdAsync(id);

                var model = new BrandDeleteViewModel
                {
                    Id = id,
                    BrandName = brand.Name,
                    ImageUrl = brand.ImageUrl
                };

                return View(model);
            }
            catch (NonExistentEntity ex)
            {
                logger.LogError(ex, "(GET)Not found request - Brand/Delete");
                return NotFound();
            }

        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, BrandDeleteViewModel model)
        {
            if (id != model.Id)
            {
                logger.LogWarning("Mismatch between route ID ({RouteId}) and model ID ({ModelId})", id, model.Id);
                return BadRequest("Invalid request");
            }
            try
            {
                var brand = await brandService.GetByIdAsync(id);

                await brandService.DeleteAsync(id);
                logger.LogInformation("Brand with ID {BrandId} successfully deleted", id);

                return RedirectToAction("All");
            }
            catch (NonExistentEntity ex)
            {
                logger.LogError(ex, "Brand with ID {BrandId} does not exist", id);
                return NotFound();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An unexpected error occurred while deleting brand with ID {BrandId}", id);
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
