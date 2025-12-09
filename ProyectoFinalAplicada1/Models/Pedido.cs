using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinalAplicada.Models;

public class Pedido
{
    [Key]
    public int PedidoId { get; set; }

    [Required(ErrorMessage = "La fecha es obligatoria")]
    public DateTime FechaPedido { get; set; } = DateTime.Now;

    [Required(ErrorMessage = "Debe seleccionar un cliente")]
    [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un cliente valido")]
    public int ClienteId { get; set; }

    [ForeignKey("ClienteId")]
    public Cliente? Cliente { get; set; }

    [Required]
    [Range(0.01, double.MaxValue, ErrorMessage = "El monto total no puede ser 0")]
    public double MontoTotal { get; set; }

    [Required(ErrorMessage = "El estado es obligatorio")]
    public string Estado { get; set; } = "Pendiente";

    [Required]
    public bool Delivery { get; set; }

    [Required(ErrorMessage = "La referencia o dirección es obligatoria")]
    [StringLength(200, ErrorMessage = "La referencia no puede exceder los 200 caracteres")]
    public string? ReferenciaSitio { get; set; }

    public ICollection<PedidoDetalle> Detalles { get; set; } = new List<PedidoDetalle>();
}