using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using ProyectoFinalAplicada1.Data; // ⬅️ AGREGAR ESTA DIRECTIVA para ApplicationUser

public static class SeedData
{
    public static async Task InitializeAsync(IServiceProvider serviceProvider)
    {
        // 1. Obtener los servicios necesarios
        // CAMBIAR de IdentityUser a ApplicationUser
        var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

        // 2. Definir los roles que quieres crear
        string[] roleNames = { "Administrador", "Cliente" };

        // ... (El bucle de creación de roles está bien) ...

        foreach (var roleName in roleNames)
        {
            if (!await roleManager.RoleExistsAsync(roleName))
            {
                await roleManager.CreateAsync(new IdentityRole(roleName));
            }
        }

        // 3. Crear un usuario Administrador (si no existe)
        const string adminEmail = "admin@gmail.com";
        const string adminPassword = "Clave123";

        if (await userManager.FindByEmailAsync(adminEmail) == null)
        {
            // CAMBIAR de IdentityUser a ApplicationUser
            var adminUser = new ApplicationUser
            {
                UserName = adminEmail,
                Email = adminEmail,
                EmailConfirmed = true,
                // Si ApplicationUser tiene campos como NombreCliente, debes inicializarlos aquí:
                // NombreCliente = "Admin", 
                // ApellidoCliente = "Sistema"
            };

            var result = await userManager.CreateAsync(adminUser, adminPassword);

            if (result.Succeeded)
            {
                // 4. Asignar el rol de "Administrador"
                await userManager.AddToRoleAsync(adminUser, "Administrador");
            }
        }
    }
}