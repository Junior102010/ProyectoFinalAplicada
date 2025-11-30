using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ProyectoFinalAplicada.Models;

namespace ProyectoFinalAplicada.Models;

public class PedidoDetalle
{
    [Key]
    public int DetalleId { get; set; }
    [Required]
    public int PedidoId { get; set; }
    [Required]
    public int ProductoId { get; set; }

    [ForeignKey("ProductoId")]
    public Producto? Producto { get; set; }
    [Required]
    public double Cantidad { get; set; }
    [Required]
    public double PrecioUnitario { get; set; }
    [Required]
    public double Importe { get; set; }

    [ForeignKey("TransferenciaId")]
    public ICollection<Transferencia> transferencia { get; set; } = new List<Transferencia>();
}
