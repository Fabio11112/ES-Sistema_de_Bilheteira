using Microsoft.AspNetCore.Identity;

namespace SistemaDeBilheteira.Services.Database.Entities;

public class User : IdentityUser, IDbItem
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } =string.Empty;
    public string Email { get; set; } = string.Empty;
    public bool IsEmailVerified { get; set; } 
    public string Role { get; set; } = string.Empty;
    public string PasswordHashed { get; set; } = String.Empty;

    public void AddAddress()
    {
        
    }

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}