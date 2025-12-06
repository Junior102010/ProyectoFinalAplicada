using Microsoft.EntityFrameworkCore;
using ProyectoFinalAplicada.Models;
using ProyectoFinalAplicada1.DAL;
using System.Linq.Expressions;

namespace ProyectoFinalAplicada.Services;

public class TranferenciaServices(IDbContextFactory<Context> DbFactory)
{
    // --- 1. MÉTODOS DE LECTURA (Buscar, Listar, Existe) ---
    public async Task<bool> Existe(int idTransferencia)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Transferencia.AnyAsync(c => c.TransferenciaId == idTransferencia);
    }

    public async Task<Transferencia?> Buscar(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        // Incluimos Imágenes para que se vean al editar
        return await contexto.Transferencia
            .Include(t => t.Imagenes)
            .Include(t => t.Cliente)
            .FirstOrDefaultAsync(c => c.TransferenciaId == id);
    }

    public async Task<List<Transferencia>> Listar(Expression<Func<Transferencia, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Transferencia
            .Include(c => c.Cliente)
            .Where(criterio)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<List<Transferencia>> GetList(Expression<Func<Transferencia, bool>> criterio)
    {
        return await Listar(criterio);
    }

    // --- 2. MÉTODOS DE GUARDADO (AQUÍ ESTÁ LA CORRECCIÓN) ---

    // OPCIÓN A: Usado por CREATE (Requiere UserId para asignar el Cliente)
    public async Task<bool> Guardar(Transferencia transferencia, int userId)
    {
        if (transferencia.TransferenciaId == 0)
        {
            return await InsertarConUsuario(transferencia, userId);
        }
        else
        {
            return await Modificar(transferencia);
        }
    }

    // OPCIÓN B: Usado por EDIT (No requiere UserId, soluciona tu error actual)
    public async Task<bool> Guardar(Transferencia transferencia)
    {
        if (transferencia.TransferenciaId > 0)
        {
            return await Modificar(transferencia);
        }
        else
        {
            // Si intentan CREAR sin usuario, lanzamos error para avisar al programador
            throw new InvalidOperationException("Para crear una transferencia debe usar Guardar(transferencia, userId)");
        }
    }

    // --- 3. LÓGICA INTERNA DE INSERCIÓN Y MODIFICACIÓN ---

    private async Task<bool> InsertarConUsuario(Transferencia transferencia, int userId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();

        // Buscamos el ClienteId basado en el Usuario logueado
        var clienteEncontrado = await contexto.Cliente
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.ClienteId == userId);

        if (clienteEncontrado == null) return false; // El usuario no tiene perfil de cliente

        // Creamos instancia LIMPIA (Solución al error de "TransferenciaId unknown")
        var nuevaTransferencia = new Transferencia
        {
            Fecha = DateTime.Now,
            Origen = transferencia.Origen,
            Destino = transferencia.Destino,
            Monto = transferencia.Monto,
            Observaciones = transferencia.Observaciones,

            ClienteId = clienteEncontrado.ClienteId, // Asignamos ID
            Cliente = null, // Desconectamos objeto para evitar error de EF
            Imagenes = new List<TransferenciaImagen>() // Imágenes vacías al crear
        };

        contexto.Transferencia.Add(nuevaTransferencia);
        var guardado = await contexto.SaveChangesAsync() > 0;

        if (guardado)
            transferencia.TransferenciaId = nuevaTransferencia.TransferenciaId;

        return guardado;
    }

    public async Task<bool> Modificar(Transferencia transferencia)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();

        // Buscamos el original en la BD
        var original = await contexto.Transferencia
            .Include(t => t.Imagenes)
            .FirstOrDefaultAsync(t => t.TransferenciaId == transferencia.TransferenciaId);

        if (original == null) return false;

        // Actualizamos valores simples (Sin tocar el ID ni relaciones peligrosas)
        original.Origen = transferencia.Origen;
        original.Destino = transferencia.Destino;
        original.Monto = transferencia.Monto;
        original.Observaciones = transferencia.Observaciones;

        // NO tocamos el ClienteId en modificar para no romper la dueñidad del registro

        // Manejo de Imágenes (Solo agregamos las nuevas)
        if (transferencia.Imagenes != null)
        {
            foreach (var imagenViene in transferencia.Imagenes)
            {
                if (imagenViene.TransferenciaImagenId == 0) // Es nueva
                {
                    var nuevaImg = new TransferenciaImagen
                    {
                        RutaImagen = imagenViene.RutaImagen,
                        TransferenciaId = original.TransferenciaId,
                        Transferencia = null
                    };
                    contexto.TransferenciaImagenes.Add(nuevaImg);
                }
            }
        }

        return await contexto.SaveChangesAsync() > 0;
    }

    // --- 4. ELIMINAR ---
    public async Task<bool> Eliminar(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var t = await contexto.Transferencia.Include(i => i.Imagenes).FirstOrDefaultAsync(x => x.TransferenciaId == id);

        if (t == null) return false;

        if (t.Imagenes.Any()) contexto.TransferenciaImagenes.RemoveRange(t.Imagenes);
        contexto.Transferencia.Remove(t);

        return await contexto.SaveChangesAsync() > 0;
    }
}