
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinalAplicada.Models;

public class Transferencia
{
    [Key]
    public int TransferenciaId { get; set; }

    [Required]
    public DateTime Fecha { get; set; } = DateTime.Now;

    [Required]
    public string Origen { get; set; } = string.Empty;

    [Required]
    public string Destino { get; set; } = string.Empty;

    [Required]
    [Range(0.01, double.MaxValue, ErrorMessage = "El monto transferido debe ser mayor a 0.")]
    public double Monto { get; set; }

    [Required]
    public string Observaciones { get; set; } = string.Empty;
    public int? ClienteId { get; set; }

    [ForeignKey("ClienteId")]
    public Cliente? Cliente { get; set; }

    public int? PedidoId { get; set; }

    [ForeignKey("PedidoId")]
    public Pedido? Pedido { get; set; }

    public ICollection<TransferenciaImagen> Imagenes { get; set; } = new List<TransferenciaImagen>();
  
}
