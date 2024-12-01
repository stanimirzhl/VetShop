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
    public class BrandService : IBrandService
    {
        private readonly IRepository<Brand> repository;

        public BrandService(IRepository<Brand> repository)
        {
            this.repository = repository;
        }

        public async Task<PagingModel<BrandServiceModel>> GetPagedBrandsAsync(string? searchTerm, int pageIndex, int pageSize)
        {
            var query = repository.All();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                searchTerm = searchTerm.Trim().ToLower();
                query = query.Where(b => b.BrandName.ToLower().Contains(searchTerm));
            }

            var pagedBrands = await PagingModel<Brand>.CreateAsync(query, pageIndex, pageSize);

            var mappedBrands = pagedBrands.Items.Select(b => new BrandServiceModel
            {
                Id = b.Id,
                Name = b.BrandName,
                ImageUrl = b.ImageUrl
            }).ToList();

            return new PagingModel<BrandServiceModel>(mappedBrands, pagedBrands.TotalCount, pageIndex, pageSize);
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
            var brand = await repository.GetByIdAsync(id);
            return brand == null ? null : new BrandServiceModel
            {
                Id = brand.Id,
                Name = brand.BrandName,
                ImageUrl = brand.ImageUrl
            };
        }

        public async Task AddAsync(BrandServiceModel brandModel)
        {
            var brand = new Brand
            {
                BrandName = brandModel.Name,
                ImageUrl = brandModel.ImageUrl
            };

            await repository.AddAsync(brand);
            await repository.SaveChangesAsync();
        }

        public async Task EditAsync(BrandServiceModel brandModel)
        {
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

            await repository.DeleteAsync(brand);
            await repository.SaveChangesAsync();
        }
    }
}
