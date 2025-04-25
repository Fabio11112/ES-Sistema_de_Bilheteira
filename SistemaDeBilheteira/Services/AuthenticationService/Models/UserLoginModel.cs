namespace SistemaDeBilheteira.Services.AuthenticationService.Models;

public class UserLoginModel
{
    public string Email { get; set; } = String.Empty;
    public string Password { get; set; } = String.Empty;
}