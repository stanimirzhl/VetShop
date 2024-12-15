using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetShop.Core.Interfaces;
using VetShop.Core.Models;
using VetShop.Infrastructure.Data.Common;
using VetShop.Infrastructure.Data.Models;

namespace VetShop.Core.Implementations
{
    public class SavedProductService : ISavedProductService
    {
        private readonly IRepository<SavedProduct> repository;
        private readonly UserManager<ApplicationUser> userManager;

        public SavedProductService(IRepository<SavedProduct> repository, UserManager<ApplicationUser> userManager)
        {
            this.repository = repository;
            this.userManager = userManager;
        }
        public async Task<IQueryable<SavedProductServiceModel>> GetAllSavedProductsAsync(string userId)
        {
            var savedProductsQuery = repository.All()
                .Where(sp => sp.UserId == userId)
                .Select(sp => new SavedProductServiceModel
                {
                    UserId = sp.UserId,
                    ProductId = sp.ProductId
                });

            return savedProductsQuery;
        }
        public async Task RemoveSavedProduct(string userId, int productId)
        {
            var savedProduct = await repository.All().FirstOrDefaultAsync(sp => sp.ProductId == productId && sp.UserId == userId);

            if (savedProduct == null)
            {
                throw new NonExistentEntity($"SavedProduct not found in saved products.");
            }
            await repository.RemoveEntityAsync(savedProduct);

            await repository.SaveChangesAsync();
        }
        public async Task AddSavedProduct(string userId, int productId)
        {
            var savedProduct = new SavedProduct()
            {
                UserId = userId,
                ProductId = productId
            };

            await repository.AddAsync(savedProduct);
        }
        public async Task<bool> IsProductSavedByUserAsync(string userId, int productId)
        {
            var savedProduct = await repository.All()
                .FirstOrDefaultAsync(sp => sp.ProductId == productId && sp.UserId == userId);

            return savedProduct != null;
        }
    }
}
