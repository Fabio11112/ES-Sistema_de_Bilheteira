namespace SistemaDeBilheteira.Services.Database.Entities;

public class User() : DbItem
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } =string.Empty;
    public string Email { get; set; } = string.Empty;
    public bool IsEmailVerified { get; set; } = false;
    public string PasswordHashed { get; set; } = String.Empty;


    public string GetFullName()
    {
        return FirstName + " " + LastName;
    }


    public void AddAddress()
    {
        
    }
}