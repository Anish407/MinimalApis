using Dish.Infra.Repositories;

namespace Dish.Core.Handlers;

public class DishService(IUnitOfWork unitOfWork) : IDishService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<List<DishesAPI.Entities.Dish>> GetDishes() => 
        await _unitOfWork.DishRepository.GetAllAsync();

    public async Task<List<DishesAPI.Entities.Dish>> GetDishesByName(string dishName) =>
        await _unitOfWork.DishRepository.Find(dish => dish.Name == dishName);
    
    public async Task<DishesAPI.Entities.Dish> GetDishById(Guid dishId) =>
        await _unitOfWork.DishRepository.SingleOrDefaultAsync(dish => dish.Id == dishId);
}