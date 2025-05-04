using Microsoft.EntityFrameworkCore.Metadata;
using SistemaDeBilheteira.Services.Database;

namespace SistemaDeBilheteira.Services.AuthenticationService.IService;

public interface IModelService<T> : IService<T> where T : DbItem
{
    IResult Add(IModel item);
}