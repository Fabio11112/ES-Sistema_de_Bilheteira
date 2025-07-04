using SistemaDeBilheteira.Components.Pages;
using SistemaDeBilheteira.Services.AuthenticationService.IService;
using SistemaDeBilheteira.Services.Database.Entities;
using SistemaDeBilheteira.Services.Database.Entities.ShoppingCart;
using SistemaDeBilheteira.Services.IService.ServiceManager;
using SistemaDeBilheteira.Services.IService;

namespace SistemaDeBilheteira.Services;

public class CartService
{
    public int ItemCount { get; set; }
    public AppUser User { get; set; }
    public event Action? OnChange;
    
    
    public void UpdateCart(int itemCount)
    {
        ItemCount = itemCount;
        NotifyStateHasChanged();
    }

    public void UpdateUser(AppUser user)
    {
        User = user;
    }

    private void NotifyStateHasChanged()
    {
        OnChange?.Invoke();
    }
    
}