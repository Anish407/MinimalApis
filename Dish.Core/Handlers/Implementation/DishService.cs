using Dish.Infra.Repositories;

namespace Dish.Core.Handlers;

public class DishService(IUnitOfWork unitOfWork) : IDishService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<List<DishesAPI.Entities.Dish>> GetDishes()
    {
        return await _unitOfWork.DishRepository.GetAllAsync();
    }
}