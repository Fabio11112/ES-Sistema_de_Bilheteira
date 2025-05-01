using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using SistemaDeBilheteira.Services.AuthenticationService.Models;
using SistemaDeBilheteira.Services.AuthenticationService.Validation;
using SistemaDeBilheteira.Services.Database.Context;
using SistemaDeBilheteira.Services.Database.Entities;
using SistemaDeBilheteira.Services.Database.Repositories;
using SistemaDeBilheteira.Services.Database.UnitOfWork;


namespace SistemaDeBilheteira.Services.AuthenticationService;

public class AuthService(IUnitOfWork unitOfWork, IUserInputValidator userInputValidator) : IAuthService
{
    private IUnitOfWork UnitOfWork { get; } = unitOfWork;
    private IUserInputValidator UserInputValidator { get; } = userInputValidator;

    
    public Task<IAuthResult> RegisterAsync(UserRegisterModel model)
    {
        var userRepository = UnitOfWork.GetRepository<AppUser>();
        IAuthResult result = new AuthResult();
        if (userRepository == null)
        {
            result.Success = false;
            result.Message = "Internal Server Error";
            return Task.FromResult(result);
        }
        
        var users = userRepository?.GetAll()!;

        if (UserAlreadyExist(users, model))
        {
            result.Success = false;
            result.Message = "The email address is already in use.";
            return Task.FromResult(result);
        }

        if (!UserInputValidator.ValidateInput(model, result))
        {
            return Task.FromResult(result);
        }
        
        AppUser user = new()
        {
            Email = model.Email,
            FirstName = model.Name,
        };
        
        user.PasswordHash = new PasswordHasher<AppUser>().HashPassword(user, model.Password);
        AddUser(user, userRepository);
        result.Success = true;
        result.Message = "The account has been created successfully.";
        return Task.FromResult(result);
    }

    public async Task<IAuthResult> LoginAsync(UserLoginModel model, HttpContext httpContext)
    {
        var userRepository = UnitOfWork.GetRepository<AppUser>();
        IAuthResult result = new AuthResult();
        if (userRepository == null)
        {
            result.Success = false;
            result.Message = "Internal Server Error";
            return result;
        }
        
        var user = userRepository.GetAll().FirstOrDefault(x => x.Email == model.Email);
        
        if (user is null || new PasswordHasher<AppUser>().VerifyHashedPassword(user, user.PasswordHash, model.Password) == PasswordVerificationResult.Failed)
        {
            result.Success = false;
            result.Message = "Invalid email or password.";
            return result;
        }

        // var claims = new List<Claim>
        // {
        //     new Claim(ClaimTypes.Email, model.Email),
        //     new Claim(ClaimTypes.Role, user.Role),
        // };
        
        // var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        // var principal = new ClaimsPrincipal(identity);
        // await httpContext.SignInAsync(principal);
        
        result.Success = true;
        result.Message = "Logged in successfully";
        return result;
    }

    public Task<IAuthResult> LogoutAsync()
    {
        throw new NotImplementedException();
    }

    private bool UserAlreadyExist(List<AppUser> users, UserRegisterModel model)
    {
        return users.Any(u => u.Email == model.Email);
    }
    

    private void AddUser(AppUser user, IRepository<AppUser> repository)
    {
        UnitOfWork.Begin();
        repository?.Insert(user);
        UnitOfWork.SaveChanges();
        UnitOfWork.Commit();
    }
}