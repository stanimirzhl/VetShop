using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using VetShop.Core;
using VetShop.Core.Implementations;
using VetShop.Core.Interfaces;
using VetShop.Core.Models;
using VetShop.Models.Brand;
using VetShop.Models.Comment;
using VetShop.Models.Product;

namespace VetShop.Controllers
{
    public class ProductController : Controller
    {
        private IProductService productService;
        private ILogger<ProductController> logger;
        private IBrandService brandService;
        private ICategoryService categoryService;
        private ICommentService commentService;
        ISavedProductService savedProductService;
        IOrderService orderService;

        public ProductController(IProductService productService, ILogger<ProductController> logger, IBrandService brandService, ICategoryService categoryService, ICommentService commentService, ISavedProductService savedProductService, IOrderService orderService)
        {
            this.productService = productService;
            this.logger = logger;
            this.brandService = brandService;
            this.categoryService = categoryService;
            this.commentService = commentService;
            this.savedProductService = savedProductService;
            this.orderService = orderService;
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
                var product = await productService.GetDetailsByIdAsync(id, 1, 10);
                var isSavedByUser = await savedProductService.IsProductSavedByUserAsync(User.FindFirstValue(ClaimTypes.NameIdentifier), id);

                if (product.Comments != null)
                {
                    var productModel = new ProductViewModel
                    {
                        Id = product.Id,
                        Title = product.Title,
                        Description = product.Description,
                        CategoryName = product.CategoryName,
                        BrandName = product.BrandName,
                        Price = product.Price,
                        Quantity = product.Quantity,
                        ImageUrl = product.ImageUrl,
                        Comments = product.Comments.Map(c => new CommentViewModel
                        {
                            Id = c.Id,
                            AuthorName = c.AuthorName,
                            Title = c.Title,
                            Description = c.Description,
                            CreatedOn = c.CreatedOn
                        })
                    };

                    var detailsModel = new ProductDetailsViewModel()
                    {
                        Product = productModel,
                        Comment = new CommentFormModel(),
                        IsSavedByUser = isSavedByUser,
                    };

                    return View(detailsModel);
                }

                var productViewModel = new ProductViewModel
                {
                    Id = product.Id,
                    Title = product.Title,
                    Description = product.Description,
                    CategoryName = product.CategoryName,
                    BrandName = product.BrandName,
                    Price = product.Price,
                    Quantity = product.Quantity,
                    ImageUrl = product.ImageUrl,
                };

                return View(new ProductDetailsViewModel()
                {
                    Product = productViewModel,
                    Comment = new CommentFormModel(),
                    IsSavedByUser = isSavedByUser,
                });
            }
            catch (NonExistentEntity ex)
            {
                return NotFound();
            }

        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddComment(int productId, ProductDetailsViewModel commentForm)
        {
            if (TryValidateModel(commentForm.Comment))
            {
                return RedirectToAction("Details", new { id = productId });
            }
            try
            {
                var product = productService.GetByIdAsync(productId);

                var serviceModel = new CommentServiceModel()
                {
                    Title = commentForm.Comment.Title,
                    Description = commentForm.Comment.Description,
                    ProductId = product.Id,
                    AuthorId = User.FindFirstValue(ClaimTypes.NameIdentifier)
                };
                await commentService.AddCommentAsync(productId, serviceModel);
            }
            catch (NonExistentEntity ex)
            {
                return NotFound();
            }

            return RedirectToAction("Details", new { id = productId });
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> SaveProduct(int productId)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            try
            {
                await productService.SaveProductAsync(userId, productId);

                TempData["SuccessMessage"] = "Product saved successfully.";
            }
            catch (NonExistentEntity ex)
            {
                return NotFound();
            }

            return RedirectToAction("Details", new { id = productId });
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> RemoveSavedProduct(int productId)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            try
            {
                await productService.RemoveSavedProduct(userId, productId);

                TempData["SuccessMessage"] = "Product successfully removed from saved list.";
            }
            catch (NonExistentEntity ex)
            {
                return NotFound();
            }

            return RedirectToAction("Details", new { id = productId });
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Saved(string? searchTerm, int pageNumber = 1, int pageSize = 8)
        {
            ViewData["SearchTerm"] = searchTerm;

            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var pagedProducts = await productService.SavedProducts(userId, searchTerm, pageNumber, pageSize);

            var pagedViewModels = pagedProducts.Map(p => new ProductViewModel()
            {
                Id = p.Id,
                Title = p.Title,
                Price = p.Price,
                ImageUrl = p.ImageUrl,
            });

            return View("Saved", pagedViewModels);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddToOrder(int productId, int quantity)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            await orderService.AddProductToOrderAsync(productId, quantity, userId);

            TempData["SuccessMessage"] = "Product successfully added to order list.";

            return RedirectToAction("Details", new { id = productId });
        }
    }
}
