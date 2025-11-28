using Microsoft.EntityFrameworkCore;
using ProyectoFinalAplicada.Models;
using ProyectoFinalAplicada1.Components.Pages;
using ProyectoFinalAplicada1.DAL;
using System.Linq.Expressions;

namespace ProyectoFinalAplicada.Services;

public class ProveedoresServices(IDbContextFactory<Context> DbFactory)
{
    public async Task<bool> Existe(int idProveedor)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Proveedor.AnyAsync(c => c.ProveedorId == idProveedor);
    }

    public async Task<Proveedor?> Buscar(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();

        return await contexto.Proveedor.FirstOrDefaultAsync(e => e.ProveedorId == id);
    }

    public async Task<List<Proveedor>> Listar(Expression<Func<Proveedor, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Proveedor.Where(criterio).AsNoTracking().ToListAsync();

    }

    public async Task<bool> Insertar(Proveedor proveedor)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Proveedor.Add(proveedor);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Guardar(Proveedor proveedor)
    {
        if (!await Existe(proveedor.ProveedorId))
        {

            return await Insertar(proveedor);
        }
        else
        {
            return await Modificar(proveedor);
        }
    }

    public async Task<bool> Modificar(Proveedor proveedor)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Update(proveedor);
        return await contexto.SaveChangesAsync() > 0;
    }

}

