using Dish.Core.Repositories;

namespace Dish.Infra.Repositories;

public interface IUnitOfWork
{
    IDishRepository DishRepository { get; set; }
    Task SaveChanges();
}