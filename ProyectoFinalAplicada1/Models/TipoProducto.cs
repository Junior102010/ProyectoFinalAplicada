using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinalAplicada.Models;

public class TipoProducto
{
    [Key]
    public int Id_Tipo { get; set; }

    [Required]
    public string NombreTipo { get; set; }

    [ForeignKey("Id_Producto")]
    public ICollection<Producto> DetalleTipo {  get; set; } = new List<Producto>();


}
