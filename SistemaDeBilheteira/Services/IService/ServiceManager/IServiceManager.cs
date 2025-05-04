using SistemaDeBilheteira.Services.AuthenticationService.IService;
using SistemaDeBilheteira.Services.Database;

namespace SistemaDeBilheteira.Services.IService.ServiceManager;

public interface IServiceManager
{
    IService<TEntity> GetService<TEntity>() where TEntity : DbItem;
}