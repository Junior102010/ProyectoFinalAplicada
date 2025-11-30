using Microsoft.EntityFrameworkCore;
using ProyectoFinalAplicada.Models;
using ProyectoFinalAplicada1.Components.Pages;
using ProyectoFinalAplicada1.DAL;
using System.Linq.Expressions;

namespace ProyectoFinalAplicada.Services;

public class TranferenciaServices(IDbContextFactory<Context> DbFactory)
{
    public async Task<bool> Existe(int idTranferencia)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Transferencia.AnyAsync(c => c.TransferenciaId == idTranferencia);
    }

    public async Task<Transferencia?> Buscar(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();

        return await contexto.Transferencia.FirstOrDefaultAsync(c => c.TransferenciaId  == id);
    }

    public async Task<List<Transferencia>> Listar(Expression<Func<Transferencia, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Transferencia.Where(criterio).AsNoTracking().ToListAsync();

    }

    public async Task<bool> Insertar(Transferencia transferencia)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Transferencia.Add(transferencia);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Guardar(Transferencia transferencia) 
    { 
        if (!await Existe(transferencia.TransferenciaId))
        {

            return await Insertar(transferencia);
        }
        else
        {
            return await Modificar(transferencia);
        }
    }

    public async Task<bool> Modificar(Transferencia transferencia)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();

        var imagenesActuales = contexto.TransferenciaImagenes
        .Where(ti => ti.TransferenciaId == transferencia.TransferenciaId);

        contexto.TransferenciaImagenes.RemoveRange(imagenesActuales);

        contexto.Entry(transferencia).State = EntityState.Modified;

        contexto.Update(transferencia);


        return await contexto.SaveChangesAsync() > 0;
    }

}