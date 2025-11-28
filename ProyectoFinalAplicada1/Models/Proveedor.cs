using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinalAplicada.Models;

public class Proveedor
{
    [Key]
    public int ProveedorId { get; set; }

    [Required]
    public string Nombre { get; set; }

    [Required]
    public string Telefono { get; set; }

    [ForeignKey("CategoriaId")]
    public ICollection<Categoria> ProveedorDetalle { get; set; } = new List<Categoria>();

}
