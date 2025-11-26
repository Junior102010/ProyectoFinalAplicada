using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinalAplicada.Models;

public class Entrada
{
    [Key]
    public int EntradaId { get; set; }

    [Required]
    public DateTime FechaEntrada { get; set; }

    [Required]
    public string Referencia { get; set; }

    [ForeignKey("ProveedorId")]
    public ICollection<Proveedor> DetalleEntrada { get; set; } = new List<Proveedor>();
}
