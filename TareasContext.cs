using appdotnet.Models;
using Microsoft.EntityFrameworkCore;

namespace appdotnet;

public class TareasContext : DbContext
{
    public DbSet<Categoria> Categorias { get; set; }

    public DbSet<Tarea> Tareas { get; set; }

    public TareasContext(DbContextOptions<TareasContext> options) : base(options) { }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        List<Categoria> categoriasInit = new List<Categoria>();
        categoriasInit.Add(new Categoria() { CategoriaId = Guid.Parse("b0e000d3-f29c-4fed-8747-3bd0734f871e"), Nombre = "Pending", Peso = 20 });
        categoriasInit.Add(new Categoria() { CategoriaId = Guid.Parse("b0e000d3-f29c-4fed-8747-3bd0734f8711"), Nombre = "Personal", Peso = 50 });


        modelBuilder.Entity<Categoria>(categoria =>
        {
            categoria.ToTable("Categoria");

            categoria.HasKey(p => p.CategoriaId);

            categoria.Property(p => p.Nombre).IsRequired().HasMaxLength(150);

            categoria.Property(p => p.Description).IsRequired(false);

            categoria.Property(p => p.Peso);

            categoria.HasData(categoriasInit);
        });

        List<Tarea> tareasInit = new List<Tarea>();

        tareasInit.Add(new Tarea() { TareaId = Guid.Parse("b0e000d3-f29c-4fed-8747-3bd0734f8730"), CategoriaId = Guid.Parse("b0e000d3-f29c-4fed-8747-3bd0734f871e"), PrioridadTarea = Prioridad.Media, Titulo = "Review public services pays", FechaCreacion = DateTime.UtcNow });
        tareasInit.Add(new Tarea() { TareaId = Guid.Parse("b0e000d3-f29c-4fed-8747-3bd0734f8721"), CategoriaId = Guid.Parse("b0e000d3-f29c-4fed-8747-3bd0734f8711"), PrioridadTarea = Prioridad.Baja, Titulo = "Netflix movie end", FechaCreacion = DateTime.UtcNow });


        modelBuilder.Entity<Tarea>(tarea =>
        {
            tarea.ToTable("Tarea");
            tarea.HasKey(p => p.TareaId);

            tarea.HasOne(p => p.Categoria).WithMany(p => p.Tareas).HasForeignKey(p => p.CategoriaId);

            tarea.Property(p => p.Titulo).IsRequired().HasMaxLength(200);

            tarea.Property(p => p.Descripcion).IsRequired(false);

            tarea.Property(p => p.PrioridadTarea);

            tarea.Property(p => p.FechaCreacion).HasColumnType("timestamp with time zone");

            tarea.HasData(tareasInit);
        });
    }

}


