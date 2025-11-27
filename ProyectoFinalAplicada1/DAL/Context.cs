using Microsoft.EntityFrameworkCore;
using ProyectoFinalAplicada.Models;

namespace ProyectoFinalAplicada1.DAL;

public class Context : DbContext
{
    public Context(DbContextOptions<Context> options) : base(options)
    {
    }

    public DbSet<Pedido> Pedido { get; set; }

    public DbSet<Usuario> Usuario { get; set; }

    public DbSet<Producto> Producto { get; set; }

    public DbSet<Entrada> Entrada { get; set; }

    public DbSet<Cliente> Cliente { get; set; }

    public DbSet<Proveedor> Proveedor { get; set; }

    public DbSet<Categoria> Categoria { get; set; }

    public DbSet<Transferencia> Transferencia { get; set; }

}
