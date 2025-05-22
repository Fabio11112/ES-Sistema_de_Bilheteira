
using Microsoft.AspNetCore.Identity;
using SistemaDeBilheteira.Services.AuthenticationService.Models;
using SistemaDeBilheteira.Services.Database.Entities;
using SistemaDeBilheteira.Services.Database.Repositories;
using SistemaDeBilheteira.Services.AuthenticationService;


namespace SistemaDeBilheteira.Services.AuthenticationService;

public class AuthService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IHttpContextAccessor httpContextAccessor) : IAuthService
{
    private UserManager<AppUser> UserManager { get; } = userManager;
    private SignInManager<AppUser> SignInManager { get; } = signInManager;
    private IHttpContextAccessor HttpContextAccessor { get; } = httpContextAccessor;

    public async Task<IResult> RegisterAsync(UserRegisterModel model)
    {
        IResult authResult = new Result();

        var user = new AppUser { UserName = model.Email, Email = model.Email, FirstName = model.Name };
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


    public async Task<IResult> LoginAsync(UserLoginModel model)
    {
        IResult authResult = new Result();
        var user = await UserManager.FindByEmailAsync(model.Email);

        if (user != null)
        {
            var result = await SignInManager.CheckPasswordSignInAsync(user, model.Password, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                // 💡 Esta línea garantiza que se emita la cookie
                await SignInManager.SignInAsync(user, isPersistent: false);

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



    public async Task<IResult> LogoutAsync()
    {
        var authResult = new Result();
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

    public async Task<AppUser?> GetAppUserAsync()
    {
        var user = HttpContextAccessor.HttpContext?.User;
        if (user == null)
            return null;

        var appUser = await UserManager.GetUserAsync(user);

        return appUser;
    }

    public async Task<IResult> ChangeEmailAsync(string newEmail)
    {
        var authResult = new Result();

        var user = await GetAppUserAsync();
        if (user == null)
        {
            authResult.Success = false;
            authResult.Message = "User not found.";
            return authResult;
        }

        var token = await UserManager.GenerateChangeEmailTokenAsync(user, newEmail);
        var result = await UserManager.ChangeEmailAsync(user, newEmail, token);

        if (result.Succeeded)
        {
            user.UserName = newEmail;
            var usernameResult = await UserManager.UpdateAsync(user);

            authResult.Success = usernameResult.Succeeded;
            authResult.Message = usernameResult.Succeeded ? "Email updated successfully." : "Email updated, but username failed.";
        }
        else
        {
            authResult.Success = false;
            authResult.Message = result.Errors.FirstOrDefault()?.Description ?? "Failed to update email.";
        }

        return authResult;
    }
    
    public async Task<IResult> ChangePasswordAsync(string currentPassword, string newPassword)
    {
        var authResult = new Result();

        var user = await GetAppUserAsync();
        if (user == null)
        {
            authResult.Success = false;
            authResult.Message = "User not found.";
            return authResult;
        }

        var result = await UserManager.ChangePasswordAsync(user, currentPassword, newPassword);
        if (result.Succeeded)
        {
            authResult.Success = true;
            authResult.Message = "Password updated successfully.";
        }
        else
        {
            authResult.Success = false;
            authResult.Message = result.Errors.FirstOrDefault()?.Description ?? "Failed to update password.";
        }

        return authResult;
    }


}