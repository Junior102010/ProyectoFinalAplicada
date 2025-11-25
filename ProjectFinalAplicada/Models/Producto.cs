using System.ComponentModel.DataAnnotations;

namespace ProyectoFinalAplicada.Models;

public class Producto
{
    [Key]
    public int Id_Producto { get; set; }

    [Required]
    public string NombreProducto { get; set; }

    [Required]
    public double PrecioCompra { get; set; }

    [Required]
    public double PrecioVenta { get; set; }

    [Required]
    public string TipoVenta { get; set; }

    [Required]
    public int Existencia { get; set; }



}
