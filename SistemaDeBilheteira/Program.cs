using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Scalar.AspNetCore;
using SistemaDeBilheteira.Components;
using SistemaDeBilheteira.Services.Database.Context;
using SistemaDeBilheteira.Services.Database.Repositories;
using SistemaDeBilheteira.Services.AuthenticationService;
using SistemaDeBilheteira.Services.AuthenticationService.IService;
using SistemaDeBilheteira.Services.AuthenticationService.Validation;
using SistemaDeBilheteira.Services.Database.Builders;
using SistemaDeBilheteira.Services.Database.Entities;
using SistemaDeBilheteira.Services.Database.UnitOfWork;
using SistemaDeBilheteira.Services.IService;
using Toolbelt.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.WebHost.UseUrls("https://localhost:7193", "http://localhost:5212");
builder.WebHost.ConfigureKestrel(serverOptions =>
{
    serverOptions.ListenAnyIP(7193, listenOptions => listenOptions.UseHttps());
    serverOptions.ListenAnyIP(5212);
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Cookie.Name = "auth_token";
        options.LoginPath = "/LogIn";
        options.Cookie.MaxAge = TimeSpan.FromHours(1);
        options.AccessDeniedPath = "/AccessDenied";
    });
builder.Services.AddAuthorization();
builder.Services.AddCascadingAuthenticationState();


builder.Services.AddDbContext<SistemaDeBilheteiraContext>();

// builder.Services.AddDefaultIdentity<AppUser>(options =>
//     {
//         options.SignIn.RequireConfirmedAccount = false;
//     })
//     .AddEntityFrameworkStores<SistemaDeBilheteiraContext>();

builder.Services.AddIdentity<AppUser, IdentityRole>()
    .AddEntityFrameworkStores<SistemaDeBilheteiraContext>()
    .AddDefaultTokenProviders();

builder.Services.AddScoped<IRepositoryFactory, RepositoryFactory>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IUserInputValidator, UserInputValidator>();
builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddScoped<IService<Address>, AddressService>();

builder.Services.AddSingleton<AddressBuilder, AddressBuilder>();


//Services configuration

builder.Services.AddRazorPages();  //  Identity needs this
builder.Services.AddAuthorization(); // for [Authorize]



var app = builder.Build();
DotNetEnv.Env.Load();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.MapScalarApiReference();
    app.UseCssLiveReload(); 
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();




app.MapStaticAssets();
app.UseAuthentication();
app.UseAuthorization();
app.UseAntiforgery();

app.MapRazorPages(); // Importante para as páginas de Login/Register
app.MapControllers();
app.MapBlazorHub();


app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();




app.Run();