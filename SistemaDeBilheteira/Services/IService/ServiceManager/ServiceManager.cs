using SistemaDeBilheteira.Services.Database;
using SistemaDeBilheteira.Services.Database.UnitOfWork;
using SistemaDeBilheteira.Services.IService.ServiceManager;

namespace SistemaDeBilheteira.Services.AuthenticationService.IService.ServiceManager;

public class ServiceManager(IUnitOfWork unitOfWork) : IServiceManager
{
    private IUnitOfWork UnitOfWork { get; } = unitOfWork;
    public IService<TEntity> GetService<TEntity>() where TEntity : DbItem
    {
        return new Service<TEntity>(UnitOfWork);
    }
}