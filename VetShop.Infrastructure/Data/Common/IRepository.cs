using System.Linq.Expressions;

namespace VetShop.Infrastructure.Data.Common
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> All();

        IQueryable<TEntity> AllReadOnly();

        Task AddAsync(TEntity entity);

        Task<int> SaveChangesAsync();

        Task<TEntity?> GetByIdAsync(object id);

        Task DeleteAsync(object id);
    }
}
