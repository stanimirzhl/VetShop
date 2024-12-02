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
    public class BrandService : IBrandService
    {
        private readonly IRepository<Brand> repository;
        ILogger<BrandService> logger;

        public BrandService(IRepository<Brand> repository, ILogger<BrandService> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<PagingModel<BrandServiceModel>> GetPagedBrandsAsync(string? searchTerm, int pageIndex, int pageSize)
        {

            logger.LogInformation("All paged brands with filter method has been invoked in the brand service");

            var query = repository
                .AllReadOnly()
                .Select(b => new BrandServiceModel
                {
                    Id = b.Id,
                    Name = b.BrandName,
                    ImageUrl = b.ImageUrl
                });

            if (!string.IsNullOrEmpty(searchTerm))
            {
                searchTerm = searchTerm.Trim().ToLower();
                query = query.Where(b => b.Name.ToLower().Contains(searchTerm));
            }
            var pagedBrands = await PagingModel<BrandServiceModel>.CreateAsync(query, pageIndex, pageSize);

            return pagedBrands;
        }



        public async Task<IEnumerable<BrandServiceModel>> GetAllAsync()
        {
            var brands = await repository.All().ToListAsync();
            return brands.Select(b => new BrandServiceModel
            {
                Id = b.Id,
                Name = b.BrandName,
                ImageUrl = b.ImageUrl
            });
        }

        public async Task<BrandServiceModel?> GetByIdAsync(int id)
        {
            logger.LogWarning("Edit brand method has been invkoed, potential exception to be thrown");
            var brand = await repository.GetByIdAsync(id);
            return brand == null ? throw new NonExistentEntity($"Brand with ID {id} not found.") : new BrandServiceModel
            {
                Id = brand.Id,
                Name = brand.BrandName,
                ImageUrl = brand.ImageUrl
            };
        }

        public async Task AddAsync(BrandServiceModel brandModel)
        {
            logger.LogInformation("Add brand method has been invoked");
            var brand = new Brand
            {
                BrandName = brandModel.Name,
                ImageUrl = brandModel.ImageUrl
            };

            await repository.AddAsync(brand);
        }

        public async Task EditAsync(BrandServiceModel brandModel)
        {
            logger.LogWarning("Edit brand method has been invoked, potential exception to be thrown");
            var brand = await repository.GetByIdAsync(brandModel.Id);

            if (brand == null)
            {
                throw new NonExistentEntity($"Brand with ID {brandModel.Id} not found.");
            }

            brand.BrandName = brandModel.Name;
            brand.ImageUrl = brandModel.ImageUrl;

            await repository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var brand = await repository.GetByIdAsync(id);

            if (brand == null)
            {
                throw new NonExistentEntity($"Brand with ID {id} not found.");
            }

            await repository.DeleteAsync(brand.Id);
            await repository.SaveChangesAsync();
        }
    }
}
