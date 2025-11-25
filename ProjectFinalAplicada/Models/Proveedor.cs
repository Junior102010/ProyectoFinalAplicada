using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinalAplicada.Models;

public class Proveedor
{
    [Key]
    public int Id_Proveedor { get; set; }

    [Required]
    public string NombreProveedor { get; set; }

    [Required]
    public string TelefonoProveedor { get; set; }

    [ForeignKey("Id_Tipo")]
    public ICollection<TipoProducto> ProveedorDetalle {  get; set; } = new List<TipoProducto>();

}
