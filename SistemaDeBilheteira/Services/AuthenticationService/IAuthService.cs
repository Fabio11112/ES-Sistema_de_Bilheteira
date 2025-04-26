using SistemaDeBilheteira.Services.AuthenticationService.Models;

namespace SistemaDeBilheteira.Services.AuthenticationService;

public interface IAuthService
{
    Task<IAuthResult> RegisterAsync(UserRegisterModel model);
    Task<IAuthResult> LoginAsync(UserLoginModel model, HttpContext context);
    Task<IAuthResult> LogoutAsync();
}