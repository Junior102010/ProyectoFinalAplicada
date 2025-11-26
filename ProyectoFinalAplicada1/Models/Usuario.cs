using System.ComponentModel.DataAnnotations;

namespace ProyectoFinalAplicada.Models;

public class  Usuario
{
    //El alpha el jefe el animal the best
    [Key]
    public int UsuarioId { get; set; }

    [Required]
    public string Nombre { get; set; }
    [Required]
    public string Clave { get; set; }
    [Required]
    public string Rol { get; set; }

}
