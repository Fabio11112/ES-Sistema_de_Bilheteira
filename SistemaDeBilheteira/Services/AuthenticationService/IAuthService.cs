using Microsoft.AspNetCore.Identity;
using SistemaDeBilheteira.Services.AuthenticationService.Models;

namespace SistemaDeBilheteira.Services.AuthenticationService;

public interface IAuthService
{
    public Task<IAuthResult> RegisterAsync(UserRegisterModel model);
    
    Task<IAuthResult> LoginAsync(UserLoginModel model);
    Task<IAuthResult> LogoutAsync();
}