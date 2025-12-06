using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ProyectoFinalAplicada.Models;

public class TransferenciaImagen
{
    [Key]
    public int TransferenciaImagenId { get; set; }

    public string RutaImagen { get; set; } = string.Empty;

  
    public int TransferenciaId { get; set; }

    [ForeignKey("TransferenciaId")] 
    public Transferencia? Transferencia { get; set; }
}