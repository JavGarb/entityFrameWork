using System.ComponentModel.DataAnnotations;

namespace appdotnet.Models;

public class Categoria
{
    [Key]
    public Guid CategoriaId{ get; set; }

     [Required]
     [MaxLength(150)]
    public string Nombre { get; set; }

    
    public string Description { get; set; }

    public int Peso { get; set; }

    public virtual ICollection<Tarea> Tareas { get; set; }
    
}