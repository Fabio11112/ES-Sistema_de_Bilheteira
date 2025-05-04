using Microsoft.EntityFrameworkCore.Metadata;
using SistemaDeBilheteira.Components.Cards.EditAdress;
using SistemaDeBilheteira.Services.Database;
using SistemaDeBilheteira.Services.Database.UnitOfWork;

namespace SistemaDeBilheteira.Services.AuthenticationService.IService;

public abstract class Service<T>(IUnitOfWork unitOfWork) : IService<T> where T : DbItem
{
    protected IUnitOfWork UnitOfWork { get; set; } = unitOfWork;


    public abstract IResult Add(T item);

    public abstract IResult Delete(Guid id);

    public abstract IResult Update(T item);

    public abstract T? GetById(Guid id);

    public abstract ICollection<T>? GetAll();
    
}