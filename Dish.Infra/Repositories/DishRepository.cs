using Dish.Core.Repositories;
using DishesAPI.DbContexts;

namespace Dish.Infra.Repositories;

public class DishRepository: BaseRepository<DishesAPI.Entities.Dish>,IDishRepository
{
    public DishRepository(DishesDbContext context) : base(context)
    {
    }
}