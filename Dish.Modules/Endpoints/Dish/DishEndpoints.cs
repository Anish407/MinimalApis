using Dish.Core.Handlers;
using DishesAPI.DbContexts;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;

// ReSharper disable All

namespace Microsoft.AspNetCore.Builder
{
    public static class DishEndpoints
    {
        public static IEndpointRouteBuilder UseDishEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapGroup("/api/Dishes");
            app.MapGet("/", GetDishes);

            return app;
        }

        private static async Task<List<DishesAPI.Entities.Dish>> GetDishes(IDishService  dishService)
        {
            return await dishService.GetDishes();
        }
    }
}