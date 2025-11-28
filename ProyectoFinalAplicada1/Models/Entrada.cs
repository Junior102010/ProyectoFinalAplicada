using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ProyectoFinalAplicada1.Models;

namespace ProyectoFinalAplicada.Models;

public class Entrada
{
    [Key]
    public int EntradaId { get; set; }

    [Required]
    public DateTime FechaEntrada { get; set; }

    [Required]
    public string Concepto { get; set; } = string.Empty;
    [Required]
    public int ProveedorId { get; set; }

    [ForeignKey("ProveedorId")]
    public Proveedor? Proveedor { get; set; }

    [ForeignKey("EntradaId")]
    public ICollection<EntradaDetalle> EntradaDetalles { get; set; } = new List<EntradaDetalle>();
}
