using Microsoft.EntityFrameworkCore;
using ProyectoFinalAplicada.DAL;
using ProyectoFinalAplicada.Models;
using System.Linq.Expressions;

namespace ProyectoFinalAplicada.Services;

public class ProductosServices(IDbContextFactory<Context> DbFactory)
{
    public async Task<bool> Existe(int idProducto)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Producto.AnyAsync(c => c.Id_Producto == idProducto);
    }

    public async Task<Producto?> Buscar(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();

        return await contexto.Producto.FirstOrDefaultAsync(e => e.Id_Producto == id);
    }

    public async Task<List<Producto>> Listar(Expression<Func<Producto, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Producto.Where(criterio).AsNoTracking().ToListAsync();

    }

    public async Task<bool> Insertar(Producto producto)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Producto.Add(producto);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> SumarProductos(Producto producto)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var productoExistente = await contexto.Producto.FirstOrDefaultAsync(e => e.Id_Producto == producto.Id_Producto);
        productoExistente.Existencia += producto.Existencia;
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> RestarProductos(Producto producto)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var productoExistente = await contexto.Producto.FirstOrDefaultAsync(e => e.Id_Producto == producto.Id_Producto);
        productoExistente.Existencia -= producto.Existencia;
        return await contexto.SaveChangesAsync() > 0;
    }
}
