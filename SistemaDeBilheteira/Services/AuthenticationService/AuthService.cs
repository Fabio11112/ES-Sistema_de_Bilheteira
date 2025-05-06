
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

    public async Task<AppUser?> GetAppUserAsync(){
        var user = HttpContextAccessor.HttpContext?.User;
        if(user == null)
            return null;

        var appUser = await UserManager.GetUserAsync(user);
        
        return appUser;
    }
    // Task<IResult> IAuthService.LoginAsync(UserLoginModel model)
    // {
    //     throw new NotImplementedException();
    // }
}