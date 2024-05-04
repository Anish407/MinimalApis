namespace Dish.Core.DTOs;

public class CreateDishResponse
{
    public Guid Id { get; set; }

    public required string Name { get; set; }

}