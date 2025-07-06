using Microsoft.AspNetCore.Identity;
using SistemaDeBilheteira.Services.Database.Context;

namespace SistemaDeBilheteira.Services.Database.Repositories;

public class RepositoryFactory : IRepositoryFactory
{
    private readonly SistemaDeBilheteiraContext _context;

    public RepositoryFactory(SistemaDeBilheteiraContext context)
    {
        _context = context;
    }

    /*
     * This method is used to create a new repository for a specific entity type.
     * It takes a generic type parameter TEntity, which must be a subclass of DbItem.
     * The method returns an instance of IRepository<TEntity>.
     */
    public IRepository<TEntity> Create<TEntity>() where TEntity : DbItem
    {
        return new Repository<TEntity>(_context);
    }
}
