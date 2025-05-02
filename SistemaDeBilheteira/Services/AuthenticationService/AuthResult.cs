namespace SistemaDeBilheteira.Services.AuthenticationService;

public class AuthResult : IAuthResult
{
    public bool Success { get; set; }
    public string Message { get; set; }
}