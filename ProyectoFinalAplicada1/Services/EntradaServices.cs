using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ProyectoFinalAplicada.Models;
using ProyectoFinalAplicada1.DAL;


namespace ProyectoFinalAplicada.Services;

public class EntradasServices(IDbContextFactory<Context> DbFactory)
{
    
    public async Task<List<Proveedor>> ListarProveedores()
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        if (!await contexto.Proveedor.AnyAsync())
        {
            contexto.Proveedor.AddRange(
                new Proveedor { Nombre = "Proveedor General (Temp)", Telefono = "809-555-0001" },
                new Proveedor { Nombre = "Almacenes del Cibao", Telefono = "809-555-0002" }
            );
            await contexto.SaveChangesAsync();
        }
        return await contexto.Proveedor.AsNoTracking().ToListAsync();
    }

    public async Task<bool> Guardar(Entrada entrada)
    {
        if (!await Existe(entrada.EntradaId))
            return await Insertar(entrada);
        else
            return await Modificar(entrada);
    }

    private async Task<bool> Existe(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Entrada.AnyAsync(e => e.EntradaId == id);
    }

    private async Task<bool> Insertar(Entrada entrada)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Entrada.Add(entrada);

        
        await AfectarExistencia(contexto, entrada.EntradaDetalles.ToArray(), true);

        return await contexto.SaveChangesAsync() > 0;
    }

    private async Task<bool> Modificar(Entrada entrada)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Update(entrada);
        return await contexto.SaveChangesAsync() > 0;
    }

    private async Task AfectarExistencia(Context contexto, EntradaDetalle[] detalles, bool sumar)
    {
        foreach (var item in detalles)
        {
            var producto = await contexto.Producto.FindAsync(item.ProductoId);
            if (producto != null)
            {
                if (sumar)
                    producto.Existencia += item.Cantidad;
                else
                    producto.Existencia -= item.Cantidad;

                contexto.Producto.Update(producto);
            }
        }
    }

    public async Task<Entrada?> Buscar(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Entrada
            .Include(e => e.Proveedor)
            .Include(e => e.EntradaDetalles)
            .ThenInclude(d => d.Producto)
            .FirstOrDefaultAsync(e => e.EntradaId == id);
    }

    public async Task<List<Entrada>> Listar(Expression<Func<Entrada, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Entrada
            .Include(e => e.Proveedor)
            .Include(e => e.EntradaDetalles)
            .Where(criterio)
            .AsNoTracking()
            .ToListAsync();
    }
}