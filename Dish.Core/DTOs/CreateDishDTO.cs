namespace Dish.Core.DTOs;

public class CreateDishDTO
{
    public required string Name { get; set; }
    public ICollection<CreateIngredientDTO> Ingredients { get; set; } = new List<CreateIngredientDTO>();
}