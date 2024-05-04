using Dish.Core.Exceptions;
using Dish.Core.Repositories;
using DishesAPI.DbContexts;
using Microsoft.Extensions.Logging;

namespace Dish.Infra.Repositories;

public class UnitOfWork(DishesDbContext context, ILogger<UnitOfWork> Logger) : IUnitOfWork
{
    public IDishRepository DishRepository { get; set; } = new DishRepository(context);


    public Task SaveChanges()
    {
        try
        {
            return context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            Logger.LogError(e.Message, e);
            throw new DatabaseException("DataBaseError", e);
        }
    }
}