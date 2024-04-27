WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.AddDishServices();

WebApplication app = builder.Build();

app.UseHttpsRedirection();
app.UseDishEndpoints();

app.Run();

