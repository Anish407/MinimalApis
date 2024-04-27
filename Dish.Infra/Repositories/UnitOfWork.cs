using Dish.Core.Repositories;
using DishesAPI.DbContexts;

namespace Dish.Infra.Repositories;

public class UnitOfWork(DishesDbContext context) : IUnitOfWork
{
    public IDishRepository DishRepository { get; set; } = new DishRepository(context);


    public Task SaveChanges()
    {
       return context.SaveChangesAsync();
    }
}