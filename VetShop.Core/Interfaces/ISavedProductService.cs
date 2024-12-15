using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetShop.Core.Models;

namespace VetShop.Core.Interfaces
{
    public interface ISavedProductService
    {
        Task<IQueryable<SavedProductServiceModel>> GetAllSavedProductsAsync(string userId);
        Task RemoveSavedProduct(string userId, int productId);
        Task AddSavedProduct(string userId, int productId);
        Task<bool> IsProductSavedByUserAsync(string userId, int productId);
    }
}
