using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetShop.Core.Models;
using VetShop.Infrastructure.Data.Models;

namespace VetShop.Core.Interfaces
{
    public interface IBrandService
    {
        Task<PagingModel<BrandServiceModel>> GetPagedBrandsAsync(string? searchTerm, int pageIndex, int pageSize);
        Task<IEnumerable<BrandServiceModel>> GetAllAsync();
        Task<BrandServiceModel?> GetByIdAsync(int id);
        Task AddAsync(BrandServiceModel brand);
        Task EditAsync(BrandServiceModel brand);
        Task DeleteAsync(int id);
        Task<List<BrandServiceModel>> GetAllBrandsAsync();
        Task<List<SelectListItem>> GetBrandsIntoSelectList();
    }
}
