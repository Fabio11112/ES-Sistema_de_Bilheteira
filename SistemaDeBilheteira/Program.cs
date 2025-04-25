using Scalar.AspNetCore;
using SistemaDeBilheteira.Components;
using SistemaDeBilheteira.Services.Database.Context;
using Microsoft.AspNetCore.Identity;
using SistemaDeBilheteira.Services.Database.Repositories;
using Microsoft.EntityFrameworkCore;
using SistemaDeBilheteira.Services.AuthenticationService;
using SistemaDeBilheteira.Services.AuthenticationService.Models;
using Toolbelt.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
//
// builder.Services.AddSingleton<Deserializer<T>>();


builder.Services.AddDbContext<SistemaDeBilheteiraContext>();
builder.Services.AddScoped<IRepositoryFactory, RepositoryFactory>();
builder.Services.AddScoped<IAuthService, AuthService>();


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


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();




app.Run();