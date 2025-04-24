using Microsoft.AspNetCore.Identity;
using Scalar.AspNetCore;
using SistemaDeBilheteira.Components;
using SistemaDeBilheteira.Services.API_Deserializer;
using SistemaDeBilheteira.Services.Movies;
using SistemaDeBilheteira.Services.Database.Context;
using SistemaDeBilheteira.Services.Database.Entities;
using SistemaDeBilheteira.Services.Database.Repositories;

using Toolbelt.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
//
// builder.Services.AddSingleton<Deserializer<T>>();







builder.Services.AddDbContext<SistemaDeBilheteiraContext>();
builder.Services.AddScoped<IRepositoryFactory, RepositoryFactory>();

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