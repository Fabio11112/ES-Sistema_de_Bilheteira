using Microsoft.AspNetCore.Identity;
using SistemaDeBilheteira.Services.AuthenticationService.Models;

namespace SistemaDeBilheteira.Services.AuthenticationService;

public interface IAuthService
{
    public Task<IResult> RegisterAsync(UserRegisterModel model);
    
    Task<IResult> LoginAsync(UserLoginModel model);
    Task<IResult> LogoutAsync();
}