using Microsoft.AspNetCore.Identity;

namespace SistemaDeBilheteira.Services.Database.Repositories;

public interface IRepositoryFactory
{
    IRepository<TEntity> Create<TEntity>() where TEntity : DbItem;
}

