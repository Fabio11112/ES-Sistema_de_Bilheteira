
using Microsoft.AspNetCore.Identity;
using SistemaDeBilheteira.Services.AuthenticationService.Models;
using SistemaDeBilheteira.Services.Database.Entities;
using SistemaDeBilheteira.Services.Database.Repositories;


namespace SistemaDeBilheteira.Services.AuthenticationService;

public class AuthService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager) : IAuthService
{
    private UserManager<AppUser> UserManager { get; } = userManager;
    private SignInManager<AppUser> SignInManager { get; } = signInManager;

    public async Task<IAuthResult> RegisterAsync(UserRegisterModel model)
    {
        IAuthResult authResult = new AuthResult();
        
        var user = new AppUser { UserName = model.Email, Email = model.Email, FirstName = model.Name};
        var result = await UserManager.CreateAsync(user, model.Password);
        if (result.Succeeded)
        {
            await SignInManager.SignInAsync(user, isPersistent: false);
            authResult.Message = "User created";
            authResult.Success = true;
        }
        else
        {
            authResult.Message = result.Errors.FirstOrDefault()?.Description!;
        }
        
        return authResult;
    }

    public async Task<IAuthResult> LoginAsync(UserLoginModel model)
    {
        IAuthResult authResult = new AuthResult();
        var user = await UserManager.FindByEmailAsync(model.Email);
        if (user != null)
        {
            var result = await SignInManager.PasswordSignInAsync(user, model.Password, isPersistent: false, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                authResult.Message = "Logged in";
                authResult.Success = true;
            }
            else
            {
                authResult.Message = "The email or password is incorrect.";
                authResult.Success = false;
            }
        }
        else
        {
            authResult.Message = "This email is not registered";
            authResult.Success = false;
        }
        
        
        return authResult;
    }
    
    
    public async Task<IAuthResult> LogoutAsync()
    {
        var authResult = new AuthResult();
        try
        {
            await SignInManager.SignOutAsync();
            authResult.Message = "User closed";
            authResult.Success = true;
        }
        catch (Exception e)
        {
            authResult.Message = e.Message;
            authResult.Success = false;
        }
        return authResult;
    }
    
}