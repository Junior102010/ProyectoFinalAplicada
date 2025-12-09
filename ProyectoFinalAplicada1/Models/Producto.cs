using System.ComponentModel.DataAnnotations;

namespace ProyectoFinalAplicada.Models;

public class Producto
{
    [Key]
    public int ProductoId { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio")]
    public string NombreProducto { get; set; }

    [Required(ErrorMessage = "El costo es obligatorio")]
    [Range(0.01, float.MaxValue, ErrorMessage = "El costo debe ser mayor a 0")]
    public double Costo { get; set; }

    [Required(ErrorMessage = "El precio es obligatorio")]
    [Range(0.01, float.MaxValue, ErrorMessage = "El precio debe ser mayor a 0")]
    public double Precio { get; set; }

    [Required(ErrorMessage = "La Unidad es obligatorio")]
    public string UnidadMedida { get; set; }

    [Required(ErrorMessage = "La categoria es obligatorio")]
    public string Categoria { get; set; }

    [Required]
    public int Existencia { get; set; }



}
