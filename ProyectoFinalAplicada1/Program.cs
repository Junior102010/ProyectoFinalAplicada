using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProyectoFinalAplicada.Services;
using ProyectoFinalAplicada1;
using ProyectoFinalAplicada1.Components;
using ProyectoFinalAplicada1.Components.Account;
using ProyectoFinalAplicada1.DAL;
using ProyectoFinalAplicada1.Data;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    options.SignIn.RequireConfirmedAccount = true;
  
})
.AddEntityFrameworkStores<ApplicationDbContext>()
.AddDefaultUI() 
.AddDefaultTokenProviders();

var ConStr = builder.Configuration.GetConnectionString("ConStr");

builder.Services.AddDbContextFactory<Context>(c =>
    c.UseSqlite(ConStr, sqliteOptions => {}));

builder.Services.AddDbContextFactory<Context>(c => c.UseSqlite(ConStr));

builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();

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

if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
  
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.MapAdditionalIdentityEndpoints();

app.Run();
