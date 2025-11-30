using ProyectoFinalAplicada1.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinalAplicada.Models;

public class Cliente
{
    [Key]
    public int ClienteId { get; set; }

    [Required]
    public string UserId { get; set; } // Enlaza con ApplicationUser.Id

    // Propiedad de navegación (Opcional, pero útil)
    [ForeignKey(nameof(UserId))]
    public ApplicationUser User { get; set; } = null!;

    [Required]
    public string NombreCliente { get; set; }

    [Required]
    public string ApellidoCliente { get; set; }

    [Required]
    public string TelefonoCliente { get; set; }

    [Required]
    public string Sector { get; set; }

    [Required]
    public string CalleCliente { get; set; }

    [Required]
    public string ViviendaCliente { get; set; }

    [Required]
    public string DescripcionCliente { get; set; }

    [ForeignKey("TransferenciaId")]
    public ICollection<Transferencia> transferencia { get; set; } = new List<Transferencia>();
}
