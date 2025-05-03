using SistemaDeBilheteira.Services.Database.Context;
using SistemaDeBilheteira.Services.Database.Entities;
using SistemaDeBilheteira.Services.Database.Repositories;
using SistemaDeBilheteira.Services.Database.UnitOfWork;

namespace SistemaDeBilheteira.Tests.Database;

public class DatabaseTest
{
    private Address Address;
    private SistemaDeBilheteiraContext Context;
    private IRepositoryFactory Factory;
    private IUnitOfWork UnitOfWork;
    private IRepository<Address> AdressRepository;

    public DatabaseTest()
    {
        Address = new Address()
        {
            City = "London",
            Country = "England",
            IsDefault = true,
            State = "Washington",
            StreetLine1 = "London",
            ZipCode = "12345"
        };
        
        Context = new MemorySistemaDeBilheteiraContext();
        Context.Database.EnsureCreated();
        
        Factory = new RepositoryFactory(Context);
        UnitOfWork = new UnitOfWork(Context, Factory);

        AdressRepository = UnitOfWork.GetRepository<Address>();
        
        UnitOfWork.Begin();
        AdressRepository.Insert(Address);
        
        UnitOfWork.SaveChanges();
    }


    [Fact]
    public void WhenAddingServersInDatabase_TheyAreStoredIfSuccess()
    {
        UnitOfWork.Commit();

        var users = AdressRepository.GetAll();
        Assert.Single(users);
    }

    [Fact]
    public void WhenAddingServersInDatabase_TheyAreNotStoredIfFailed()
    {
        UnitOfWork.Rollback();
        
        var adresses = AdressRepository.GetAll();
        Assert.Empty(adresses);
    }
}