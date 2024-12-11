using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetShop.Core.Models;

namespace VetShop.Core.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryServiceModel>> GetAllAsync();
        Task<List<SelectListItem>> GetCategoriesIntoSelectList();
    }
}
