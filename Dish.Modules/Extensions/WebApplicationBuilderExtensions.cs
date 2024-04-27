using Dish.Core.Handlers;
using Dish.Infra.Repositories;
using DishesAPI.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

// ReSharper disable All

namespace Microsoft.AspNetCore.Builder;

public static class WebApplicationBuilderExtensions
{
    public static WebApplicationBuilder AddDishServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<DishesDbContext>(o => o.UseSqlite(
            builder.Configuration["ConnectionStrings:DishesDBConnectionString"]));

        builder.AddServices();
        builder.AddRepositories();

        return builder;
    }

    public static WebApplicationBuilder AddServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IDishService, DishService>();

        return builder;
    }

    public static WebApplicationBuilder AddRepositories(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
        return builder;
    }
}