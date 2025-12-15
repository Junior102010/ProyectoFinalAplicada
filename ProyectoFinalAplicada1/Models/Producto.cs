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

    [Required(ErrorMessage = "El precio para cliente es obligatorio")]
    [Range(1, 100000, ErrorMessage = "El precio debe ser mayor a 0")]

    public double Precio { get; set; }

    [Required(ErrorMessage = "El precio para empresas es obligatorio")]
    [Range(1, 100000, ErrorMessage = "El precio debe ser mayor a 0")]
    public double PrecioEmpresa { get; set; } 

    [Required]
    public string UnidadMedida { get; set; }
    [Required]
    public string Categoria { get; set; }

    [Required]
    public int Existencia { get; set; }



}
