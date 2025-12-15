using System.ComponentModel.DataAnnotations;

namespace ProyectoFinalAplicada.Models;

public class Proveedor
{
    [Key]
    public int ProveedorId { get; set; }

    [Required(ErrorMessage = "La fecha es obligatoria")]
    public DateTime FechaRegistro { get; set; } = DateTime.Now;

    [Required(ErrorMessage = "El nombre es obligatorio")]
    public string Nombre { get; set; } = string.Empty;

    [Required(ErrorMessage = "El RNC es obligatorio")]
    [StringLength(11, MinimumLength = 11, ErrorMessage = "El RNC debe tener 11 dígitos")]
    public string RNC { get; set; } = string.Empty;

    [Required(ErrorMessage = "El correo es obligatorio")]
    [EmailAddress(ErrorMessage = "Formato de correo inválido")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "La dirección es obligatoria")]
    public string Direccion { get; set; } = string.Empty;

    [Required(ErrorMessage = "El teléfono es obligatorio")]
    [RegularExpression(@"^\d{3}-\d{3}-\d{4}$", ErrorMessage = "Formato: 000-000-0000")]
    public string Telefono { get; set; } = string.Empty;

    [Required(ErrorMessage = "Indique los días de entrega")]
    public string DiasEntrega { get; set; } = string.Empty; 
}