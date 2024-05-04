using Dish.Core.Handlers;
using DishesAPI.DbContexts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;

// ReSharper disable All

namespace Microsoft.AspNetCore.Builder
{
    public static class DishEndpoints
    {
        public static IEndpointRouteBuilder UseDishEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api");
            group.MapGet("/", GetDishes);
            group.MapGet("/Dishes", GetDishesByOptionalQuery);
            group.MapGet("/Dishes/{dishId:guid}", GetDishById);

            return app;
        }

        private static async Task<IResult> GetDishById(IDishService dishService,
            Guid dishId)
        {
            var dish = await dishService.GetDishById(dishId);

            if (dish is null)
            {
                return Results.NotFound();
            }

            return TypedResults.Ok(dish);
        }

        private static async Task<List<DishesAPI.Entities.Dish>> GetDishesByOptionalQuery(IDishService dishService,
            [FromQuery] string? name) // type string is automatically inferred from the query string, so the [FromQuery] is optional
        {
            return string.IsNullOrWhiteSpace(name)? await dishService.GetDishes() :await dishService.GetDishesByName(name);
        }

        private static async Task<List<DishesAPI.Entities.Dish>> GetDishes(IDishService  dishService)
        {
            return await dishService.GetDishes();
        }
    }
}