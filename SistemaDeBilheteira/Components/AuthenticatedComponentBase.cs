using System.Security.Claims;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace SistemaDeBilheteira.Components;

public abstract class AuthenticatedComponentBase : ComponentBase
{
    [Inject] protected AuthenticationStateProvider AuthProvider { get; set; } = null!;
    protected ClaimsPrincipal? User { get; private set; }
    protected string? UserId { get; private set; }

    protected override async Task OnInitializedAsync()
    {
        var authState = await AuthProvider.GetAuthenticationStateAsync();
        User = authState.User;

        if (User.Identity?.IsAuthenticated == true)
        {
            UserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }
    }
}