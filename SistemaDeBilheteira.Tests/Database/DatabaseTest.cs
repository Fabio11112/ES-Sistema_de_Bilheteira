using SistemaDeBilheteira.Services.Database.Context;
using SistemaDeBilheteira.Services.Database.Entities;
using SistemaDeBilheteira.Services.Database.Repositories;
using SistemaDeBilheteira.Services.Database.UnitOfWork;

namespace SistemaDeBilheteira.Tests.Database;

public class DatabaseTest
{
    private AppUser User = new AppUser();
    private SistemaDeBilheteiraContext Context;
    private IRepositoryFactory Factory;
    private IUnitOfWork UnitOfWork;
    private IRepository<AppUser> UserRepository;

    public DatabaseTest()
    {
        User.FirstName = "João";
        User.LastName = "Roberto";
        User.Email = "roberto@gmail.com";
        Context = new MemorySistemaDeBilheteiraContext();
        Context.Database.EnsureCreated();
        
        Factory = new RepositoryFactory(Context);
        UnitOfWork = new UnitOfWork(Context, Factory);

        UserRepository = UnitOfWork.GetRepository<AppUser>();
        
        UnitOfWork.Begin();
        UserRepository.Insert(User);
        
        UnitOfWork.SaveChanges();
    }


    [Fact]
    public void WhenAddingServersInDatabase_TheyAreStoredIfSuccess()
    {
        UnitOfWork.Commit();

        var users = UserRepository.GetAll();
        Assert.Single(users);
    }

    [Fact]
    public void WhenAddingServersInDatabase_TheyAreNotStoredIfFailed()
    {
        UnitOfWork.Rollback();
        
        var servers = UserRepository.GetAll();
        Assert.Empty(servers);
    }
}