using System.ComponentModel.DataAnnotations;

namespace ProyectoFinalAplicada.Models;

public class Cliente
{
    [Key]
    public int Id_Cliente { get; set; }

    [Required]
    public string NombreCliente { get; set; }

    [Required]
    public string ApellidoCliente { get; set; }

    [Required]
    public string TelefonoCliente { get; set; }

    [Required]
    public string ContrasenaCliente { get; set; }

    [Required]
    public string Sector { get; set; }

    [Required]
    public string CalleCliente { get; set; }

    [Required]
    public string NumViviendaCliente { get; set; }

    [Required]
    public string DescripcionCliente { get; set; }
}
