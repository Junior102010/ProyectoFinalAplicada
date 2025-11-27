using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ProyectoFinalAplicada.Models;

namespace ProyectoFinalAplicada.Models;

    public class EntradaDetalle
    {
    [Key]
    public int DetalleId { get; set; }
    public int EntradaId { get; set; }

    [Required]
    public int ProductoId { get; set; }

    [Required]
    
    public int Cantidad { get; set; }

    [ForeignKey("ProductoId")]
    public Producto? Producto { get; set; }
}
