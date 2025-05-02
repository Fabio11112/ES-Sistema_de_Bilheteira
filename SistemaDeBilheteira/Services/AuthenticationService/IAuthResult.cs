namespace SistemaDeBilheteira.Services.AuthenticationService;

public interface IAuthResult
{
    public bool Success { get; set; }
    public string Message { get; set; }
}