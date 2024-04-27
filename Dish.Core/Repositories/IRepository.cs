using System.Linq.Expressions;

namespace Dish.Core.Repositories;

public interface IRepository<TEntity> where TEntity : class
{
    Task AddAsync(TEntity entity);
    Task AddRangeAsync(IEnumerable<TEntity> entities);
    Task<List<TEntity>> Find(Expression<Func<TEntity, bool>> predicate);
    Task<List<TEntity>> GetAllAsync();
    ValueTask<TEntity> GetByIdAsync(int id);
    void Remove(TEntity entity);
    void RemoveRange(IEnumerable<TEntity> entities);
    Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
}