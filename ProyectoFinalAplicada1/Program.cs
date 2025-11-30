using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProyectoFinalAplicada.Services;
using ProyectoFinalAplicada1.Components;
using ProyectoFinalAplicada1.Components.Account;
using ProyectoFinalAplicada1.DAL;
using ProyectoFinalAplicada1.Data;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();

//builder.Services.AddAuthentication(options =>
//    {
//        options.DefaultScheme = IdentityConstants.ApplicationScheme;
//        options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
//    })
//    .AddIdentityCookies();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    options.SignIn.RequireConfirmedAccount = true;
    // Opciones de configuración adicionales
})
.AddEntityFrameworkStores<ApplicationDbContext>()
.AddDefaultUI() // Asegura que todos los servicios de la UI (incluyendo el de roles) estén presentes
.AddDefaultTokenProviders();

var ConStr = builder.Configuration.GetConnectionString("ConStr");

builder.Services.AddDbContextFactory<Context>(c =>
    c.UseSqlite(ConStr, sqliteOptions =>
    {
        // 🔑 FORZAR LA VERIFICACIÓN DE CLAVE FORÁNEA (CRÍTICO EN SQLITE)
        // Aunque a menudo es el default, a veces forzarlo ayuda.
        // No hay un método directo aquí, la mejor forma es revisar la cadena de conexión.
    }));

builder.Services.AddDbContextFactory<Context>(c => c.UseSqlite(ConStr));

builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();
//Services
builder.Services.AddScoped<ProductosServices>();
builder.Services.AddScoped<EntradasServices>();
builder.Services.AddScoped<PedidosServices>();
builder.Services.AddScoped<UsuarioServices>();
builder.Services.AddScoped<ClientesServices>();
builder.Services.AddScoped<ProveedoresServices>();
builder.Services.AddSingleton<PageTitleService>();
builder.Services.AddScoped<TranferenciaServices>();
builder.Services.AddScoped<CarritoService>();



var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        // Llamada a la función de inicialización de datos
        await SeedData.InitializeAsync(services);
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "Ocurrió un error al sembrar la base de datos con roles.");
    }
}

if (app.Environment.IsDevelopment())
{
    // ...
}

app.UseHttpsRedirection();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// Add additional endpoints required by the Identity /Account Razor components.
app.MapAdditionalIdentityEndpoints();

app.Run();
