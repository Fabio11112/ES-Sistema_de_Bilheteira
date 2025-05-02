using Microsoft.AspNetCore.Identity;

namespace SistemaDeBilheteira.Services.Database.Entities;

public class AppUser : IdentityUser, IDbItem
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } =string.Empty;
    public ICollection<Address> Addresses { get; set; } = new List<Address>();
    
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public void AddAddress()
    {
        
    }

}