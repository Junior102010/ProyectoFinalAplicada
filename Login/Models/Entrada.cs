using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinalAplicada.Models;

public class Entrada
{
    [Key]
    public int Id_Entrada { get; set; }

    [Required]
    public DateTime FechaEntrada { get; set; }

    [Required]
    public string RefFactura { get; set; }

    [ForeignKey("Id_Proveedor")]
    public ICollection<Proveedor> DetalleEntrada { get; set; } = new List<Proveedor>();
}
