using System.Text.Json;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using SistemaDeBilheteira.Services.AuthenticationService;
using SistemaDeBilheteira.Services.Database.Entities;
using SistemaDeBilheteira.Services.Database.Entities.User;

namespace SistemaDeBilheteira.Components;

public abstract class AuthenticatedComponentBase : ComponentBase
{
    [Inject] protected AuthenticationStateProvider AuthProvider { get; set; } = null!;

    [Inject] protected IAuthService AuthService { get; set; } = null!;

    protected AppUser? User { get; private set; }
    protected string? UserId { get; private set; }
    
    protected override async Task OnInitializedAsync()
    {
        User = await AuthService.GetAppUserAsync();
        
    }
    
}