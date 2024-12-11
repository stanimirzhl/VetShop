using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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

namespace VetShop.Core.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> repository;
        private ILogger<CategoryService> logger;

        public CategoryService(IRepository<Category> repository, ILogger<CategoryService> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }
        public async Task<IEnumerable<CategoryServiceModel>> GetAllAsync()
        {
            var categories = await repository.All().ToListAsync();
            return categories.Select(b => new CategoryServiceModel
            {
                Id = b.Id,
                Name = b.Name,
            });
        }

        public async Task<List<SelectListItem>> GetCategoriesIntoSelectList()
        {
            var categories =  await this.GetAllAsync();
            return categories.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name

            }).ToList();
        }
    }
}
