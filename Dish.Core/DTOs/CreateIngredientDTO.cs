namespace Dish.Core.DTOs;

public class CreateIngredientDTO
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
}