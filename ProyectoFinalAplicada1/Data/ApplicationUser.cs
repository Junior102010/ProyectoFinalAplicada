using Microsoft.AspNetCore.Identity;

namespace ProyectoFinalAplicada1.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        // Agrega las propiedades de Cliente que son necesarias para la cuenta/perfil de Identity
        public string NombreCliente { get; set; } = string.Empty;
        public string ApellidoCliente { get; set; } = string.Empty;
        public string TelefonoCliente { get; set; } = string.Empty;

        // Puedes dejar la información de dirección si es crítica para el registro,
        // o moverla a un paso posterior o a un modelo separado.
        public string Sector { get; set; } = string.Empty;
        public string CalleCliente { get; set; } = string.Empty;
        public string ViviendaCliente { get; set; } = string.Empty;
        public string DescripcionCliente { get; set; } = string.Empty;
    }

}
