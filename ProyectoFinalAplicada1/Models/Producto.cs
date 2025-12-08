using System.ComponentModel.DataAnnotations;

namespace ProyectoFinalAplicada.Models;

public class Producto
{
    [Key]
    public int ProductoId { get; set; }

    [Required]
    public string NombreProducto { get; set; }

    [Required]
    public double Costo { get; set; }

    [Required]
    public double Precio { get; set; }

    [Required]
    public string UnidadMedida { get; set; }
    [Required]
    public string Categoria { get; set; }

    [Required]
    public int Existencia { get; set; }



}
