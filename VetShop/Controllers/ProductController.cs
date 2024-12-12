using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VetShop.Core;
using VetShop.Core.Implementations;
using VetShop.Core.Interfaces;
using VetShop.Core.Models;
using VetShop.Models.Brand;
using VetShop.Models.Product;

namespace VetShop.Controllers
{
    public class ProductController : Controller
    {
        private IProductService productService;
        ILogger<ProductController> logger;
        private IBrandService brandService;
        private ICategoryService categoryService;

        public ProductController(IProductService productService, ILogger<ProductController> logger, IBrandService brandService, ICategoryService categoryService)
        {
            this.productService = productService;
            this.logger = logger;
            this.brandService = brandService;
            this.categoryService = categoryService;
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
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new ProductFormModel
            {
                Categories = await categoryService.GetCategoriesIntoSelectList(),
                Brands = await brandService.GetBrandsIntoSelectList()
            };

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Add(ProductFormModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = await categoryService.GetCategoriesIntoSelectList();

                model.Brands = await brandService.GetBrandsIntoSelectList();

                return View(model);
            }

            var product = new ProductServiceModel()
            {
                Title = model.Title,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                BrandId = model.BrandId,
                CategoryId = model.CategoryId,
                Quantity = model.Quantity,
                Price = model.Price,
            };

            await productService.AddAsync(product);
            return RedirectToAction("All");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var product = await productService.GetByIdAsync(id);

                var model = new ProductFormModel
                {
                    Title = product.Title,
                    Description = product.Description,
                    Price = product.Price,
                    ImageUrl = product.ImageUrl,
                    CategoryId = product.CategoryId,
                    BrandId = product.BrandId,
                    Quantity = product.Quantity,
                    Categories = await categoryService.GetCategoriesIntoSelectList(),
                    Brands = await brandService.GetBrandsIntoSelectList()
                };

                return View(model);
            }
            catch (NonExistentEntity ex)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, ProductFormModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = await categoryService.GetCategoriesIntoSelectList();
                model.Brands = await brandService.GetBrandsIntoSelectList();
                return View(model);
            }
            try
            {
                var existingProduct = await productService.GetByIdAsync(id);
                var productServiceModel = new ProductServiceModel
                {
                    Id = id,
                    Title = model.Title,
                    Description = model.Description,
                    Price = model.Price,
                    ImageUrl = model.ImageUrl,
                    CategoryId = model.CategoryId,
                    BrandId = model.BrandId,
                    Quantity = model.Quantity
                };

                await productService.EditAsync(productServiceModel);
                return RedirectToAction("All");
            }
            catch (NonExistentEntity ex)
            {
                return NotFound();
            }
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var product = await productService.GetByIdAsync(id);

                var viewModel = new ProductDeleteViewModel
                {
                    Id = product.Id,
                    Title = product.Title,
                    CategoryName = product.CategoryName,
                    BrandName = product.BrandName,
                    Price = product.Price,
                    Quantity = product.Quantity,
                    ImageUrl = product.ImageUrl
                };

                return View(viewModel);
            }
            catch (NonExistentEntity ex)
            {
                return NotFound();
            }
            
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id, ProductDeleteViewModel model)
        {
            if (id != model.Id)
            {
                logger.LogWarning("Mismatch between route ID ({RouteId}) and model ID ({ModelId})", id, model.Id);
                return BadRequest("Invalid request");
            }
            try
            {
                var brand = await productService.GetByIdAsync(id);

                await productService.DeleteAsync(id);

                return RedirectToAction("All");
            }
            catch (NonExistentEntity ex)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var product = await productService.GetByIdAsync(id);

                var viewModel = new ProductViewModel
                {
                    Id = product.Id,
                    Title = product.Title,
                    Description = product.Description,
                    CategoryName = product.CategoryName,
                    BrandName = product.BrandName,
                    Price = product.Price,
                    Quantity = product.Quantity,
                    ImageUrl = product.ImageUrl
                };

                return View(viewModel);
            }
            catch (NonExistentEntity ex)
            {
                return NotFound();
            }

        }

    }
}
