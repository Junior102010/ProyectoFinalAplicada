using System.ComponentModel.DataAnnotations;

namespace ProyectoFinalAplicada.Models;

public class Admin
{
    //El alpha el jefe el animal the best
    [Key]
    public int Id_Admin {  get; set; }

    [Required]
    public string NombreAdmin { get; set; }

    [Required]
    public string ApellidoAdmin { get; set; }

    [Required]
    public string TelefonoAdmin { get; set; }

    [Required]
    public string ContrasenaAdmin { get; set; }




}
