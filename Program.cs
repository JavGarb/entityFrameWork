using appdotnet;
using appdotnet.Models;
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
    return Results.Ok("Base de datos: " + dbContext.Database.CanConnect());
});

app.MapGet("/api/tasks", async ([FromServices] TareasContext dbContext) =>
{
    var tasks = await dbContext.Tareas.Include(p => p.Categoria).ToListAsync();
    return Results.Ok(tasks);
});

app.MapPost("/api/tasks", async ([FromServices] TareasContext dbContext, [FromBody] Tarea tarea) =>
{
    tarea.TareaId = Guid.NewGuid();
    tarea.FechaCreacion = DateTime.UtcNow;
    
    await dbContext.AddAsync(tarea);
    await dbContext.SaveChangesAsync();

    return Results.Ok();
});

app.MapGet("/api/categories", async ([FromServices] TareasContext dbContext) =>
{
    var categories = await dbContext.Categorias.ToListAsync();
    return Results.Ok(categories);
});

app.Run();
