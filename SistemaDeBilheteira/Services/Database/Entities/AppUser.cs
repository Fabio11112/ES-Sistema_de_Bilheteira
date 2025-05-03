using Microsoft.AspNetCore.Identity;

namespace SistemaDeBilheteira.Services.Database.Entities;

public class AppUser : IdentityUser, IDbItem
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } =string.Empty;
    public ICollection<ShoppingCartItem> ShoppingCartItems { get; set; } = new List<ShoppingCartItem>();
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public void AddAddress()
    {
        
    }
    
}