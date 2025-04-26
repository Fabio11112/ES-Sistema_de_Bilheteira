namespace SistemaDeBilheteira.Services.Database.Entities;

public class User() : DbItem
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
}