
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SistemaDeBilheteira.Services.Database.Context;
using SistemaDeBilheteira.Services.Database.Entities;
using SistemaDeBilheteira.Services.Database.Repositories;
using SistemaDeBilheteira.Services.AuthenticationService;
using SistemaDeBilheteira.Services.AuthenticationService.IService;
using SistemaDeBilheteira.Services.AuthenticationService.Validation;
using SistemaDeBilheteira.Services.Database.UnitOfWork;
using SistemaDeBilheteira.Services.IService;
using Toolbelt.Extensions.DependencyInjection;
using Scalar.AspNetCore;
using SistemaDeBilheteira.Components;
using SistemaDeBilheteira.Services.AuthenticationService.IService.ServiceManager;
using SistemaDeBilheteira.Services.Database.Builders;
using SistemaDeBilheteira.Services.IService.ServiceManager;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
    
DotNetEnv.Env.Load();

// Config o DbContext com SQLite
builder.Services.AddDbContext<SistemaDeBilheteiraContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Config Identity with custom user and role classes
builder.Services.AddIdentity<AppUser, AppRole>()
    .AddEntityFrameworkStores<SistemaDeBilheteiraContext>()
    .AddDefaultTokenProviders();

// Autenticação por cookie
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Cookie.Name = "auth_token";
        options.LoginPath = "/LogIn";
        // options.Cookie.MaxAge = TimeSpan.FromHours(1);
        options.AccessDeniedPath = "/AccessDenied";
    });

builder.Services.AddAuthorization();
builder.Services.AddCascadingAuthenticationState();


// Razor e Blazor
builder.Services.AddRazorPages();  
builder.Services.AddRazorComponents().AddInteractiveServerComponents();

// Serviços customizados
builder.Services.AddScoped<IRepositoryFactory, RepositoryFactory>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IUserInputValidator, UserInputValidator>();
builder.Services.AddScoped<IAuthService, AuthService>();

// builder.Services.AddScoped<IService<T>, Service<T>>();
builder.Services.AddScoped<IServiceManager, ServiceManager>();

//BUILDERS
builder.Services.AddSingleton<AddressBuilder, AddressBuilder>();
builder.Services.AddSingleton<CardBuilder, CardBuilder>();
builder.Services.AddSingleton<RentalBuilder, RentalBuilder>();
builder.Services.AddSingleton<ShoppingCartItemBuilder, ShoppingCartItemBuilder>();


//Services configuration

builder.Services.AddRazorPages();  //  Identity needs this
builder.Services.AddAuthorization(); // for [Authorize]

builder.Services.AddHttpContextAccessor(); // for IHttpContextAccessor

// Configurar Kestrel e portas
builder.WebHost.UseUrls("https://localhost:7193", "http://localhost:5212");
builder.WebHost.ConfigureKestrel(serverOptions =>
{
    serverOptions.ListenAnyIP(7193, listenOptions => listenOptions.UseHttps());
    serverOptions.ListenAnyIP(5212);
});

var app = builder.Build();

// Pipeline HTTP
if (!app.Environment.IsDevelopment())
{
    app.MapScalarApiReference();
    app.UseCssLiveReload(); 
    app.UseDeveloperExceptionPage();
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.MapStaticAssets();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.UseAntiforgery();

app.MapRazorPages();
app.MapControllers();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();

