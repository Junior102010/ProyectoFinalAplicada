using Microsoft.EntityFrameworkCore;
using ProyectoFinalAplicada.Models;
using ProyectoFinalAplicada1.Data;
using ProyectoFinalAplicada1.Models;

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

    public DbSet<TransferenciaImagen> TransferenciaImagenes { get; set; }

    public DbSet<Categoria> Categoria { get; set; }

    public DbSet<Transferencia> Transferencia { get; set; }

    public DbSet<EntradaDetalle> EntradaDetalles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Mapeo explícito de la relación Cliente.UserId -> AspNetUsers.Id
        modelBuilder.Entity<Cliente>()
            .HasOne<ApplicationUser>()
            .WithOne()
            .HasForeignKey<Cliente>(c => c.UserId)
            .IsRequired();
        modelBuilder.Ignore<ApplicationUser>();
    }
}
