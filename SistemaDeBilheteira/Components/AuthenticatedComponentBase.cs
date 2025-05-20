using System.Security.Claims;
using System.Text.Json;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using SistemaDeBilheteira.Services.AuthenticationService;
using SistemaDeBilheteira.Services.Database.Entities;

namespace SistemaDeBilheteira.Components;

public abstract class AuthenticatedComponentBase : ComponentBase
{
    [Inject] protected AuthenticationStateProvider AuthProvider { get; set; } = null!;

    [Inject] protected IAuthService AuthService { get; set; } = null!;

    protected AppUser? User { get; private set; }
    protected string? UserId { get; private set; }
    private JsonSerializerOptions? _jsonSerializerOptions;
    
    protected override async Task OnInitializedAsync()
    {
        User = await AuthService.GetAppUserAsync();
        
        _jsonSerializerOptions= new JsonSerializerOptions
        {
            ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles,
            WriteIndented = true
        };
    }
    
}