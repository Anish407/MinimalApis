namespace Dish.Core.Handlers;

public interface IDishService
{
    Task<List<DishesAPI.Entities.Dish>> GetDishes();
}