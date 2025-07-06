using SistemaDeBilheteira.Services.AuthenticationService.IService;
using SistemaDeBilheteira.Services.Database;

namespace SistemaDeBilheteira.Services.IService.ServiceManager;

/*
 * ServiceManager is a class that manages the services in the application.
 * It is responsible for creating and returning instances of services.
 * It uses a generic type parameter to allow for different types of services to be created.
 */
public interface IServiceManager
{
    IService<TEntity> GetService<TEntity>() where TEntity : DbItem;
}