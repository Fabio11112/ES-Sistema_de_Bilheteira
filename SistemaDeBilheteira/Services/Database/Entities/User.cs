namespace SistemaDeBilheteira.Services.Database.Entities;

public class User(string firstName, string lastName, string email) : DbItem
{
    public string FirstName { get; set; } = firstName;
    public string LastName { get; set; } = lastName;
    public string Email { get; set; } = email;
    public bool IsEmailVerified { get; set; }

    
    public string getFullName()
    {
        return FirstName + " " + LastName;
    }


    public void AddAddress()
    {
        
    }
}