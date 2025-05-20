
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SistemaDeBilheteira.Services.Database.Context;
using SistemaDeBilheteira.Services.Database.Entities;
using SistemaDeBilheteira.Services.Database.Repositories;
using SistemaDeBilheteira.Services.AuthenticationService;
using SistemaDeBilheteira.Services.AuthenticationService.Validation;
using SistemaDeBilheteira.Services.Database.UnitOfWork;
using Toolbelt.Extensions.DependencyInjection;
using Scalar.AspNetCore;
using SistemaDeBilheteira.Components;
using SistemaDeBilheteira.Services.AuthenticationService.IService.ServiceManager;
using SistemaDeBilheteira.Services.Database.Builders;
using SistemaDeBilheteira.Services.Database.Builders.CinemaSystemBuilder;
using SistemaDeBilheteira.Services.Database.Entities.PaymentSystem;
using SistemaDeBilheteira.Services.Database.Entities.ProductSystem.PhysicalMedia;
using SistemaDeBilheteira.Services.IService.ServiceManager;

using SistemaDeBilheteira.Services.Database.Entities.ProductSystem;


using SistemaDeBilheteira.Services.UI;


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
builder.Services.AddSingleton<PhysicalMedia, PhysicalMedia>();
builder.Services.AddSingleton<MediaBuilder, MediaBuilder>();
builder.Services.AddSingleton<CinemaTicketBuilder, CinemaTicketBuilder>();
builder.Services.AddSingleton<SeatBuilder, SeatBuilder>();
builder.Services.AddSingleton<FunctionBuilder, FunctionBuilder>();

builder.Services.AddScoped<IPurchaseSystem, PurchaseSystem>();


//Services configuration

builder.Services.AddRazorPages();  //  Identity needs this
builder.Services.AddAuthorization(); // for [Authorize]
builder.Services.AddSingleton<NotificationService>();


builder.Services.AddHttpContextAccessor(); // for IHttpContextAccessor

// Configurar Kestrel e portas
builder.WebHost.UseUrls("https://localhost:7193", "http://localhost:5212");
builder.WebHost.ConfigureKestrel(serverOptions =>
{
    serverOptions.ListenAnyIP(7193, listenOptions => listenOptions.UseHttps());
    serverOptions.ListenAnyIP(5212);
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<SistemaDeBilheteiraContext>();

    SeedCinemas(context);
    SeedAuditories(context);

    var service = services.GetRequiredService<IServiceManager>();
    
    SeedFormats(service);

}

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
return;


void SeedCinemas(SistemaDeBilheteiraContext context)
{
    if (!context.Cinemas.Any())
    {
        var cinemas = new List<Cinema>
        {
            new Cinema { Id = Guid.NewGuid(), Name = "Madeira Movie Center" },
            new Cinema { Id = Guid.NewGuid(), Name = "Cinemas NOS" },
            new Cinema { Id = Guid.NewGuid(), Name = "Cine Place" }
        };

        context.Cinemas.AddRange(cinemas);
        context.SaveChanges();

        Console.WriteLine("✔ Cines añadidos a la base de datos");
    }
}

void SeedAuditories(SistemaDeBilheteiraContext context)
{
    if (!context.Auditories.Any())
    {
        var auditories = new List<Auditory>
        {
            new Auditory { Id = Guid.NewGuid(), Name = "Auditorio 1" },
            new Auditory { Id = Guid.NewGuid(), Name = "Auditorio 2" },
            new Auditory { Id = Guid.NewGuid(), Name = "Auditorio 3" }
        };

        context.Auditories.AddRange(auditories);
        context.SaveChanges();

        Console.WriteLine("✔ Auditorios añadidos a la base de datos");
    }
}
void SeedFormats(IServiceManager manager)
{
    var service = manager.GetService<PhysicalMediaFormat>();
    if (service.GetAll()!.Count != 0)
        return;
    
    var formats = new List<PhysicalMediaFormat>
    {
        new PhysicalMediaFormat { FormatName = "DVD", Quality = "1080p", Emoji = "\ud83d\udcbf"},
        new PhysicalMediaFormat { FormatName = "Blu-Ray", Quality = "2160p", Emoji = "\ud83d\udcc0"},
    };

    foreach (var format in formats)
    {
        service.Add(format);
    }

    Console.WriteLine("✔ Physical media formats added");
}
