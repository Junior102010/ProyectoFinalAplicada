using ProyectoFinalAplicada1.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinalAplicada.Models;

public class Transferencia
{
    [Key]
    public int TransferenciaId { get; set; }

    [Required]
    public DateTime Fecha { get; set; } = DateTime.Now;
    [Required]
    public string Origen { get; set; }
    [Required]
    public string Destino { get; set; }
    [Required]
    public double Monto { get; set; }
    [Required]
    public string Observaciones { get; set; }

    public ICollection<TransferenciaImagen> Imagenes { get; set; } = new List<TransferenciaImagen>();
    //[ForeignKey("UsuarioId")]
    //public Usuario? Usuario { get; set; }
}
