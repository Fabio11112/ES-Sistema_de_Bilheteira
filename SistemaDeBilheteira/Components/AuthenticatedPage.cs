using Microsoft.AspNetCore.Components;
using SistemaDeBilheteira.Services.UI;
namespace SistemaDeBilheteira.Components;

public class AuthenticatedPage : AuthenticatedComponentBase
{
    [Inject] protected NavigationManager NavigationManager { get; set; } = null!;
    [Inject] protected NotificationService NotificationService { get; set; } = null!;

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        if (User == null)
        {
            NavigationManager.NavigateTo("/login");
            NotificationService.Notify("You must be logged in to access this page");
        }
    }
}