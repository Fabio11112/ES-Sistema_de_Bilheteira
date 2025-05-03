using System.Security.Claims;

namespace SistemaDeBilheteira.Services.AuthenticationService;

public interface IUserContext
{
    ClaimsPrincipal? User { get; }
    string? UserId { get; }
    Task InitializeAsync();
}