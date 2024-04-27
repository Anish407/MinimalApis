using Dish.Core.Handlers;
using DishesAPI.DbContexts;
using Microsoft.AspNetCore.Http;
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

        private static async Task<DishesAPI.Entities.Dish> GetDishById(IDishService dishService,
            Guid dishId)
        {
            return await dishService.GetDishById(dishId);
        }

        private static async Task<List<DishesAPI.Entities.Dish>> GetDishesByOptionalQuery(IDishService dishService,
            [FromQuery] string? name)
        {
            return string.IsNullOrWhiteSpace(name)? await dishService.GetDishes() :await dishService.GetDishesByName(name);
        }

        private static async Task<List<DishesAPI.Entities.Dish>> GetDishes(IDishService  dishService)
        {
            return await dishService.GetDishes();
        }
    }
}