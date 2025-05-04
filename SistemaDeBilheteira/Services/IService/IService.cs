using SistemaDeBilheteira.Services.AuthenticationService.Models;
using SistemaDeBilheteira.Services.Database;

namespace SistemaDeBilheteira.Services.AuthenticationService.IService;

public interface IService<T> where T : DbItem
{
    IResult Add(T item);
    IResult Delete(Guid id);
    IResult Update(T item);
    T? GetById(Guid id);
    ICollection<T>? GetAll();
}