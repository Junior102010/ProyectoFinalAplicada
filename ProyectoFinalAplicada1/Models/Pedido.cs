using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinalAplicada.Models;

public class Pedido
{
    [Key]
    public int Id_Pedido { get; set; }

    [Required]
    public string NombreCliente { get; set; }

    [Required]
    public string TelefonoCliente { get; set; }

    [Required]
    public string RefSitio { get; set; }

    [Required]
    public DateTime FechaPedido { get; set; }

    [Required]
    public string Estado { get; set; }

    [Required]
    public double Cantidad { get; set; }

    [Required]
    public double MontoTotal { get; set; }

    [Required]
    public bool Deliveri { get; set; }

    [ForeignKey("Id_Producto")]
    public ICollection<Producto> DetallePedido { get; set; } = new List<Producto>();

}
