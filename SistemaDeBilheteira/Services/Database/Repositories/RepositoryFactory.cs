using Microsoft.AspNetCore.Identity;
using SistemaDeBilheteira.Services.Database.Context;

namespace SistemaDeBilheteira.Services.Database.Repositories;

public class RepositoryFactory(SistemaDeBilheteiraContext context): IRepositoryFactory
{
    private readonly SistemaDeBilheteiraContext _context = context;
    
    public IRepository<TEntity> Create<TEntity>() where TEntity : IdentityUser, IDbItem
    {
        return new Repository<TEntity>(_context);
    }
}