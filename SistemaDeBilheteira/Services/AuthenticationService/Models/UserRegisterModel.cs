namespace SistemaDeBilheteira.Services.AuthenticationService.Models;

public class UserRegisterModel
{
    public string Name { get; set; } = String.Empty;
    public string Email { get; set; } = String.Empty;
    public string Password { get; set; } = String.Empty;
    public string ConfirmPassword { get; set; } = String.Empty;
}