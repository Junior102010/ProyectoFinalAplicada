using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinalAplicada.Models;

public class Categoria
{
    [Key]
    public int CategoriaId { get; set; }

    [Required]
    public string Nombre { get; set; }

   


}
