using System.ComponentModel.DataAnnotations;

namespace ProyectoFinalAplicada.Models;

public class Sector
{
    [Key]
    public int SectorId { get; set; }

    [Required(ErrorMessage = "El nombre del sector es obligatorio")]
    public string Nombre { get; set; } = string.Empty; 
    [Required]
    public string Municipio { get; set; } = "El Factor"; 

    public double PrecioEnvio { get; set; } = 0; 
}
