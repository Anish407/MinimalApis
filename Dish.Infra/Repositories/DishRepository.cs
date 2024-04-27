using Dish.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Dish.Infra.Repositories;

public class DishRepository: BaseRepository<DishesAPI.Entities.Dish>,IDishRepository
{
    public DishRepository(DbContext context) : base(context)
    {
    }
}