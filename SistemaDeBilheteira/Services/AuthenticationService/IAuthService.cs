using Microsoft.AspNetCore.Identity;
using SistemaDeBilheteira.Services.AuthenticationService.Models;
using SistemaDeBilheteira.Services.Database.Entities;

namespace SistemaDeBilheteira.Services.AuthenticationService;

public interface IAuthService
{
    public Task<IResult> RegisterAsync(UserRegisterModel model);
    Task<IResult> LoginAsync(UserLoginModel model);
    Task<IResult> LogoutAsync();
    Task<AppUser?> GetAppUserAsync();
    
    Task<IResult> ChangeEmailAsync(string newEmail);
    Task<IResult> ChangePasswordAsync(string currentPassword, string newPassword);

}