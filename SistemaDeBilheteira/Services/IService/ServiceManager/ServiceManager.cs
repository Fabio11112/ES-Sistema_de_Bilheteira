using SistemaDeBilheteira.Services.Database;
using SistemaDeBilheteira.Services.Database.UnitOfWork;
using SistemaDeBilheteira.Services.IService;
using SistemaDeBilheteira.Services.IService.ServiceManager;

namespace SistemaDeBilheteira.Services.AuthenticationService.IService.ServiceManager;

/*
 * ServiceManager is a class that manages the services in the application.
 * It is responsible for creating and returning instances of services.
 * It uses a generic type parameter to allow for different types of services to be created.
 */
public class ServiceManager(IUnitOfWork unitOfWork) : IServiceManager
{
    private IUnitOfWork UnitOfWork { get; } = unitOfWork;
    public IService<TEntity> GetService<TEntity>() where TEntity : DbItem
    {
        return new Service<TEntity>(UnitOfWork);
    }
}