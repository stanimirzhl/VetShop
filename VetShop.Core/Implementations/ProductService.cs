﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetShop.Core.Interfaces;
using VetShop.Core.Models;
using VetShop.Infrastructure.Data.Common;
using VetShop.Infrastructure.Data.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace VetShop.Core.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> repository;
        private ILogger<ProductService> logger;
        private readonly ICommentService commentService;
        private readonly UserManager<ApplicationUser> userManager;
        ISavedProductService savedProductService;

        public ProductService(IRepository<Product> repository, ILogger<ProductService> logger, ICommentService commentService, UserManager<ApplicationUser> userManager, ISavedProductService savedProductService)
        {
            this.repository = repository;
            this.logger = logger;
            this.commentService = commentService;
            this.userManager = userManager;
            this.savedProductService = savedProductService;
        }

        public async Task<IEnumerable<ProductServiceModel>> GetAllAsync()
        {
            return await repository.All()
                .Where(p => !p.IsDeleted)
                .Select(p => new ProductServiceModel
                {
                    Id = p.Id,
                    Title = p.Title,
                    Description = p.Description,
                    Price = p.Price,
                    ImageUrl = p.ImageUrl,
                    CategoryId = p.CategoryId,
                    BrandId = p.BrandId,
                    Quantity = p.Quantity,
                    IsDeleted = p.IsDeleted
                })
                .ToListAsync();
        }

        public async Task<ProductServiceModel?> GetDetailsByIdAsync(int id, int pageIndex, int pageSize)
        {
            var product = await repository.All().Include(p => p.Category).Include(p => p.Brand).Include(x => x.Comments).ThenInclude(x => x.Author)
                .FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);

            if (product == null) throw new NonExistentEntity($"Product with ID {id} not found.");

            if (product.Comments.Count > 0)
            {
                return new ProductServiceModel
                {
                    Id = product.Id,
                    Title = product.Title,
                    Description = product.Description,
                    Price = product.Price,
                    ImageUrl = product.ImageUrl,
                    CategoryId = product.CategoryId,
                    CategoryName = product.Category.Name,
                    BrandId = product.BrandId,
                    BrandName = product.Brand.BrandName,
                    Quantity = product.Quantity,
                    IsDeleted = product.IsDeleted,
                    Comments = await commentService.GetPagedCommentsAsync(id, pageIndex, pageSize)
                };
            }

            return new ProductServiceModel
            {
                Id = product.Id,
                Title = product.Title,
                Description = product.Description,
                Price = product.Price,
                ImageUrl = product.ImageUrl,
                CategoryId = product.CategoryId,
                CategoryName = product.Category.Name,
                BrandId = product.BrandId,
                BrandName = product.Brand.BrandName,
                Quantity = product.Quantity,
                IsDeleted = product.IsDeleted,
            };
        }
        public async Task<ProductServiceModel?> GetByIdAsync(int id)
        {
            var product = await repository.All().Include(p => p.Category).Include(p => p.Brand)
                .FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);

            if (product == null) throw new NonExistentEntity($"Product with ID {id} not found.");

            return new ProductServiceModel
            {
                Id = product.Id,
                Title = product.Title,
                Description = product.Description,
                Price = product.Price,
                ImageUrl = product.ImageUrl,
                CategoryId = product.CategoryId,
                CategoryName = product.Category.Name,
                BrandId = product.BrandId,
                BrandName = product.Brand.BrandName,
                Quantity = product.Quantity,
                IsDeleted = product.IsDeleted
            };
        }

        public async Task AddAsync(ProductServiceModel product)
        {
            var newProduct = new Product
            {
                Title = product.Title,
                Description = product.Description,
                Price = product.Price,
                ImageUrl = product.ImageUrl,
                CategoryId = product.CategoryId,
                BrandId = product.BrandId,
                Quantity = product.Quantity
            };

            await repository.AddAsync(newProduct);
        }

        public async Task EditAsync(ProductServiceModel product)
        {
            var existingProduct = await repository.All()
                .FirstOrDefaultAsync(p => p.Id == product.Id && !p.IsDeleted);

            if (existingProduct == null) throw new NonExistentEntity($"Product with ID {product.Id} not found.");

            existingProduct.Title = product.Title;
            existingProduct.Description = product.Description;
            existingProduct.Price = product.Price;
            existingProduct.ImageUrl = product.ImageUrl;
            existingProduct.CategoryId = product.CategoryId;
            existingProduct.BrandId = product.BrandId;
            existingProduct.Quantity = product.Quantity;

            await repository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var product = await repository.All().FirstOrDefaultAsync(p => p.Id == id);

            if (product == null) throw new NonExistentEntity($"Product with ID {id} not found.");

            product.IsDeleted = true;
            await repository.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProductServiceModel>> GetByCategoryAsync(int categoryId)
        {
            return await repository.All()
                .Where(p => p.CategoryId == categoryId && !p.IsDeleted)
                .Select(p => new ProductServiceModel
                {
                    Id = p.Id,
                    Title = p.Title,
                    Description = p.Description,
                    Price = p.Price,
                    ImageUrl = p.ImageUrl,
                    CategoryId = p.CategoryId,
                    BrandId = p.BrandId,
                    Quantity = p.Quantity,
                    IsDeleted = p.IsDeleted
                })
                .ToListAsync();
        }

        public async Task<PagingModel<ProductServiceModel>> GetPagedProductsAsync(string? searchTerm, int pageIndex, int pageSize, List<int>? brandIds = null)
        {
            var query = repository.AllReadOnly()
              .Where(x => !x.IsDeleted)
              .Select(p => new ProductServiceModel
              {
                  Id = p.Id,
                  Title = p.Title,
                  Description = p.Description,
                  Price = p.Price,
                  ImageUrl = p.ImageUrl,
                  CategoryId = p.CategoryId,
                  BrandId = p.BrandId,
                  Quantity = p.Quantity,
                  IsDeleted = p.IsDeleted
              });

            if (!string.IsNullOrEmpty(searchTerm))
            {
                searchTerm = searchTerm.Trim().ToLower();
                query = query.Where(b => b.Title.ToLower().Contains(searchTerm));
            }

            if (brandIds != null && brandIds.Any())
            {
                query = query.Where(p => brandIds.Contains((int)p.BrandId));
            }

            var pagedProducts = await PagingModel<ProductServiceModel>.CreateAsync(query, pageIndex, pageSize);
            return pagedProducts;
        }
        public async Task SaveProductAsync(string userId, int productId)
        {
            var product = await repository.GetByIdAsync(productId);

            if (product == null) throw new NonExistentEntity($"Product with ID {productId} not found.");

            await savedProductService.AddSavedProduct(userId, productId);
        }
        public async Task RemoveSavedProduct(string userId, int productId)
        {
            var product = await repository.GetByIdAsync(productId);

            if (product == null) throw new NonExistentEntity($"Product with ID {productId} not found.");

            await savedProductService.RemoveSavedProduct(userId, productId);
        }
        public async Task<PagingModel<ProductServiceModel>> SavedProducts(string userId, string? searchTerm, int pageIndex, int pageSize)
        {
            var savedProductsQuery = await savedProductService.GetAllSavedProductsAsync(userId);

            var savedProductDetailsQuery = savedProductsQuery
                .Join(
                    repository.All(),
                    sp => sp.ProductId,
                    p => p.Id,
                    (sp, p) => new ProductServiceModel
                    {
                        Id = p.Id,
                        Title = p.Title,
                        Description = p.Description,
                        Price = p.Price,
                        ImageUrl = p.ImageUrl
                    });

            if (!string.IsNullOrEmpty(searchTerm))
            {
                searchTerm = searchTerm.Trim().ToLower();
                savedProductDetailsQuery = savedProductDetailsQuery.Where(p => p.Title.Contains(searchTerm));
            }

            return await PagingModel<ProductServiceModel>.CreateAsync(savedProductDetailsQuery, pageIndex, pageSize);
        }
    }
}
