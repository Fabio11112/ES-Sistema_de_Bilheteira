using SistemaDeBilheteira.Services.AuthenticationService.Models;

namespace SistemaDeBilheteira.Services.AuthenticationService;

public interface IAuthService
{
    Task<bool> RegisterAsync(UserRegisterModel model);
    Task<bool> LoginAsync(UserLoginModel model);
    Task<bool> LogoutAsync();
}