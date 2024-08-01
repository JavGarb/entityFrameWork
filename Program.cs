using appdotnet;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<TareasContext>(options => options.UseNpgsql(connectionString));


var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/dbconection", async ([FromServices] TareasContext dbContext) =>
{
    dbContext.Database.EnsureCreated();
    return Results.Ok("Base de datos en memoria: " + dbContext.Database.CanConnect());
});

app.Run();
