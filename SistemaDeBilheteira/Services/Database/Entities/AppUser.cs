using Microsoft.AspNetCore.Identity;
using SistemaDeBilheteira.Services.Database.Entities.ShoppingCart;

namespace SistemaDeBilheteira.Services.Database.Entities;

public class AppUser : IdentityUser, IDbItem
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } =string.Empty;
    public ICollection<ShoppingCartItem> ShoppingCartItems { get; set; } = new List<ShoppingCartItem>();
    public ICollection<Address> Addresses { get; set; } = new List<Address>();
    
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public void AddAddress()
    {
        
    }
    
}