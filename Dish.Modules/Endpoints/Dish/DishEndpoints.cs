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

        // Always specify the expected return types
        private static async Task<Results<NotFound, Ok<DishesAPI.Entities.Dish?>>> GetDishById
        (IDishService dishService,
            Guid dishId)
        {
            DishesAPI.Entities.Dish? dish = await dishService.GetDishById(dishId);

            if (dish is null)
            {
                return TypedResults.NotFound();
            }

            return TypedResults.Ok(dish)!;
        }

        private static async Task<Results<NotFound, Ok<List<DishesAPI.Entities.Dish>> >> GetDishesByOptionalQuery(IDishService dishService,
            [FromQuery] string? name) // type string is automatically inferred from the query string, so the [FromQuery] is optional
        {
            var dishes = string.IsNullOrWhiteSpace(name)?  await dishService.GetDishes() :await dishService.GetDishesByName(name);

            if (!dishes.Any())
            {
              return  TypedResults.NotFound();
            }

            return TypedResults.Ok(dishes);
        }

        private static async Task<Results<NotFound, Ok<List<DishesAPI.Entities.Dish>> >> GetDishes(IDishService  dishService)
        {
            var dishes = await dishService.GetDishes();
            
            if (!dishes.Any())
            {
                return  TypedResults.NotFound();
            }

            return TypedResults.Ok(dishes);
        }
    }
}