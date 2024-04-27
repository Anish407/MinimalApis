using System.Linq.Expressions;
using Dish.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Dish.Infra.Repositories;

public class BaseRepository<TEntity>(DbContext context) : IRepository<TEntity>
    where TEntity : class
{
    public async Task AddAsync(TEntity entity) => await context.Set<TEntity>().AddAsync(entity);

    public async Task AddRangeAsync(IEnumerable<TEntity> entities)
    {
        await context.Set<TEntity>().AddRangeAsync(entities);
    }

    public Task<List<TEntity>> Find(Expression<Func<TEntity, bool>> predicate)
    {
        return context.Set<TEntity>().Where(predicate).ToListAsync();
    }

    public async Task<List<TEntity>> GetAllAsync()
    {
        return await context.Set<TEntity>().ToListAsync();
    }

    public ValueTask<TEntity> GetByIdAsync(int id)
    {
        return context.Set<TEntity>().FindAsync(id);
    }

    public void Remove(TEntity entity)
    {
        context.Set<TEntity>().Remove(entity);
    }

    public void RemoveRange(IEnumerable<TEntity> entities)
    {
        context.Set<TEntity>().RemoveRange(entities);
    }

    public Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return context.Set<TEntity>().SingleOrDefaultAsync(predicate);
    }
}