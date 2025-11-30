using System.ComponentModel.DataAnnotations;

namespace ProyectoFinalAplicada1.Models;

public class TransferenciaImagen
{
    [Key]
    public int TransferenciaImagenId { get; set; }

    [Required]
    public int TransferenciaId { get; set; } // Clave Foránea

    [Required]
    // **Aquí es donde guardas la ruta (string) en SQL**
    public string RutaImagen { get; set; }
}
