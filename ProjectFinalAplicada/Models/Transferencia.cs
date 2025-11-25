using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinalAplicada.Models;

public class Transferencia
{
    [Key]
    public int Id_Transferencia { get; set; }

    [Required]
    public string NumTransferencia { get; set; }

    [Required]
    public DateTime FechaTransferencia { get; set; }

    [ForeignKey("Id_Pedido")]
    public ICollection<Pedido> DetalleTransferencia { get; set; } = new List<Pedido>();
}
