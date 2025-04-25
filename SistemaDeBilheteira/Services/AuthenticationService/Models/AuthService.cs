using Microsoft.AspNetCore.Identity;
using SistemaDeBilheteira.Services.Database.Context;
using SistemaDeBilheteira.Services.Database.Entities;
using SistemaDeBilheteira.Services.Database.Repositories;
using SistemaDeBilheteira.Services.Database.UnitOfWork;

namespace SistemaDeBilheteira.Services.AuthenticationService.Models;

public class AuthService(SistemaDeBilheteiraContext context, IRepositoryFactory factory) : IAuthService
{
    private UnitOfWork UnitOfWork { get; } = new UnitOfWork(context, factory);
    private IRepository<User> Users { get; set; }
    
    public async Task<bool> RegisterAsync(UserRegisterModel model)
    {
        SetUp();
        
        List<User> users = Users.GetAll();
        
        if (UserAlreadyExist(users, model))
            return false;

        User user = new();
        user.Email = model.Email;
        user.FirstName = model.Name;

        user.PasswordHashed = new PasswordHasher<User>().HashPassword(user, model.Password);
        UnitOfWork.Begin();
        Users.Insert(user);
        UnitOfWork.SaveChanges();
        UnitOfWork.Commit();

        return true;
    }

    public Task<bool> LoginAsync(UserLoginModel model)
    {
        SetUp();
        throw new NotImplementedException();
    }

    public Task<bool> LogoutAsync()
    {
        throw new NotImplementedException();
    }
    
    private void SetUp()
    {
        Users = UnitOfWork.GetRepository<User>();
    }

    private bool UserAlreadyExist(List<User> users, UserRegisterModel model)
    {
        return users.Any(u => u.Email == model.Email);
    }
}