using SistemaDeBilheteira.Services.Database;
using IResult = SistemaDeBilheteira.Services.AuthenticationService.IResult;

namespace SistemaDeBilheteira.Services.IService;

public interface IService<T> where T : DbItem
{
    IResult Add(T item);
    IResult Delete(T item);
    IResult Update(T item);
    T? GetById(Guid id);
    ICollection<T>? GetAll();
    ICollection<T>? GetWithQuery(Func<IQueryable<T>, IQueryable<T>> queryBuilder);
}