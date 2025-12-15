using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;

namespace ProyectoFinalAplicada.Models;

public class Pedido
{
    [Key]
    public int PedidoId { get; set; }

    [Required(ErrorMessage = "La fecha del pedido es obligatoria.")]
    [DataType(DataType.DateTime)]
    public DateTime FechaPedido { get; set; } = DateTime.Now;

    [Required(ErrorMessage = "Debe seleccionar un cliente.")]
    [Range(1, int.MaxValue, ErrorMessage = "El ID del cliente debe ser un valor positivo.")]
    public int ClienteId { get; set; }

    [ForeignKey("ClienteId")]
    public Cliente? Cliente { get; set; }

    [Range(0.01, double.MaxValue, ErrorMessage = "El Monto Total debe ser mayor que cero.")]
    public double MontoTotal { get; set; }

    [Required(ErrorMessage = "El método de pago es obligatorio.")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "El Método de Pago debe tener entre 3 y 50 caracteres.")]
    public string MetodoPago { get; set; } = "Efectivo";

    [Required(ErrorMessage = "El estado del pedido es obligatorio.")]
    [StringLength(50, MinimumLength = 5, ErrorMessage = "El Estado debe tener entre 5 y 50 caracteres.")]
    public string Estado { get; set; } = "Pendiente";

    [Required(ErrorMessage = "Debe especificar si requiere Delivery (true/false).")]
    public bool Delivery { get; set; }

    [StringLength(250, ErrorMessage = "La referencia no puede exceder los 250 caracteres.")]
    public string? ReferenciaSitio { get; set; } 

    public ICollection<PedidoDetalle> Detalles { get; set; } = new List<PedidoDetalle>();
}