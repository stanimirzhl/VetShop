using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace VetShop.Infrastructure.Data.Common
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly VetShopDbContext dbContext;
        private readonly DbSet<TEntity> dbSet;
        private readonly ILogger<Repository<TEntity>> logger;

        public Repository(VetShopDbContext dbContext, ILogger<Repository<TEntity>> logger)
        {
            this.dbContext = dbContext;
            this.dbSet = dbContext.Set<TEntity>();
            this.logger = logger;
        }

        public IQueryable<TEntity> All()
        {
            logger.LogInformation("All entities method has been invoked");
            return dbSet.AsQueryable();
        }


        public IQueryable<TEntity> AllReadOnly()
        {
            logger.LogInformation("All read-only entities method has been invoked");
            return dbSet.AsNoTracking();
        }

        public async Task AddAsync(TEntity entity)
        {
            logger.LogInformation("Add entity method has been invoked");
            await dbSet.AddAsync(entity);
            await this.SaveChangesAsync();
        }

        public async Task<int> SaveChangesAsync()
        {
            logger.LogInformation("Save changes method has been invoked");
            return await dbContext.SaveChangesAsync();
        }

        public async Task<TEntity?> GetByIdAsync(object id)
        {
            logger.LogInformation("Get entity by id method has been invoked");
            return await dbSet.FindAsync(id);
        }
        public async Task DeleteAsync(object id)
        {
            TEntity? entity = await GetByIdAsync(id);

            if (entity != null)
            {
                dbSet.Remove(entity);
            }
        }
    }
}
