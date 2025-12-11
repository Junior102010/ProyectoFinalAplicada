using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProyectoFinalAplicada1.Data;

namespace ProyectoFinalAplicada.Services;

public class AdminEmpresasService(UserManager<ApplicationUser> userManager)
{
    
    public async Task<List<ApplicationUser>> ListarEmpresas()
    {
       
        var usuarios = await userManager.Users.ToListAsync();
        return usuarios.Where(u => u.EsEmpresa).ToList();
    }

   
    public async Task<bool> CambiarEstado(string userId, string nuevoEstado)
    {
        var user = await userManager.FindByIdAsync(userId);
        if (user == null) return false;

        user.EstadoCredito = nuevoEstado;
        var result = await userManager.UpdateAsync(user);

        return result.Succeeded;
    }
}