﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetShop.Core.Models;

namespace VetShop.Core.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductServiceModel>> GetAllAsync();
        Task<ProductServiceModel?> GetByIdAsync(int id);
        Task AddAsync(ProductServiceModel product);
        Task EditAsync(ProductServiceModel product);
        Task DeleteAsync(int id);
        Task<IEnumerable<ProductServiceModel>> GetByCategoryAsync(int categoryId);
        Task<PagingModel<ProductServiceModel>> GetPagedProductsAsync(string? searchTerm, int pageIndex, int pageSize, List<int>? brandIds = null);
        Task<ProductServiceModel?> GetDetailsByIdAsync(int id, int pageIndex, int pageSize);
        Task SaveProductAsync(string userId, int productId);
        Task RemoveSavedProduct(string userId, int productId);
        Task<PagingModel<ProductServiceModel>> SavedProducts(string userId, string? searchTerm, int pageIndex, int pageSize);
    }
}
