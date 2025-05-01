using Microsoft.AspNetCore.Identity;

namespace SistemaDeBilheteira.Services.Database.Entities;

public class User : IdentityUser, IDbItem
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } =string.Empty;
    
    public void AddAddress()
    {
        
    }

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}