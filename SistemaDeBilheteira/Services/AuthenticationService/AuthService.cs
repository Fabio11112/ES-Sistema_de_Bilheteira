
using Microsoft.AspNetCore.Identity;
using SistemaDeBilheteira.Services.AuthenticationService.Models;
using SistemaDeBilheteira.Services.Database.Entities;
using SistemaDeBilheteira.Services.Database.Repositories;


namespace SistemaDeBilheteira.Services.AuthenticationService;

public class AuthService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager) : IAuthService
{
    // private IUnitOfWork UnitOfWork { get; } = unitOfWork;
    // private IUserInputValidator UserInputValidator { get; } = userInputValidator;
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
    
    
    // public Task<IAuthResult> RegisterAsync(UserRegisterModel model)
    // {
    //     var userRepository = UnitOfWork.GetRepository<AppUser>();
    //     IAuthResult result = new AuthResult();
    //     if (userRepository == null)
    //     {
    //         result.Success = false;
    //         result.Message = "Internal Server Error";
    //         return Task.FromResult(result);
    //     }
    //     
    //     var users = userRepository?.GetAll()!;
    //
    //     if (UserAlreadyExist(users, model))
    //     {
    //         result.Success = false;
    //         result.Message = "The email address is already in use.";
    //         return Task.FromResult(result);
    //     }
    //
    //     if (!UserInputValidator.ValidateInput(model, result))
    //     {
    //         return Task.FromResult(result);
    //     }
    //     
    //     AppUser user = new()
    //     {
    //         Email = model.Email,
    //         FirstName = model.Name,
    //     };
    //     
    //     user.PasswordHash = new PasswordHasher<AppUser>().HashPassword(user, model.Password);
    //     AddUser(user, userRepository);
    //     result.Success = true;
    //     result.Message = "The account has been created successfully.";
    //     return Task.FromResult(result);
    // }
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