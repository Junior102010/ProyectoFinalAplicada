using Microsoft.EntityFrameworkCore;
using ProyectoFinalAplicada.Models;
using ProyectoFinalAplicada1.Components.Pages;
using ProyectoFinalAplicada1.DAL;
using System.Linq.Expressions;

namespace ProyectoFinalAplicada.Services;

public class PedidosServices(IDbContextFactory<Context> DbFactory)
{
    public async Task<bool> Existe(int idPedido)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Pedido.AnyAsync(c => c.PedidoId == idPedido);
    }

    public async Task<Pedido?> Buscar(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();

        return await contexto.Pedido.FirstOrDefaultAsync(e => e.PedidoId == id);
    }

    public async Task<List<Pedido>> Listar(Expression<Func<Pedido, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Pedido.Where(criterio).AsNoTracking().ToListAsync();

    }

    public async Task<bool> Insertar(Pedido producto)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Pedido.Add(producto);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Guardar(Pedido pedido)
    {
        if (!await Existe(pedido.PedidoId))
        {

            return await Insertar(pedido);
        }
        else
        {
            return await Modificar(pedido);
        }
    }

    public async Task<bool> Modificar(Pedido pedido)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();


        contexto.Update(pedido);


        return await contexto.SaveChangesAsync() > 0;
    }

}
