using Dish.Core.DTOs;

namespace Dish.Core.Handlers;

public interface IDishService
{
    Task<List<DishesAPI.Entities.Dish>> GetDishes();
    Task<List<DishesAPI.Entities.Dish>> GetDishesByName(string dishName);
    Task<DishesAPI.Entities.Dish> GetDishById(Guid dishId);
    Task Create(CreateDishDTO dishDto);
}