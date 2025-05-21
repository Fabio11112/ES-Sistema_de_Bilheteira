using Microsoft.AspNetCore.Components;
using SistemaDeBilheteira.Services.UI;
namespace SistemaDeBilheteira.Components;

public class AuthenticatedPage : AuthenticatedComponentBase
{
    [Inject] protected NavigationManager NavigationManager { get; set; } = null!;
    [Inject] protected NotificationService NotificationService { get; set; } = null!;

    protected override async Task OnParametersSetAsync()
    {
        await base.OnParametersSetAsync();
        if (User == null)
        {
            NavigationManager.NavigateTo("/login", forceLoad: true);
            NotificationService.Notify("You must be logged in to access this page");
        }
    }
}