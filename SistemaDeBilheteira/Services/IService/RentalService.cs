using SistemaDeBilheteira.Services.AuthenticationService;
using SistemaDeBilheteira.Services.AuthenticationService.IService;
using SistemaDeBilheteira.Services.Database.Entities.ProductSystem;
using SistemaDeBilheteira.Services.Database.UnitOfWork;
using IResult = SistemaDeBilheteira.Services.AuthenticationService.IResult;

namespace SistemaDeBilheteira.Services.IService;

public class RentalService (IUnitOfWork unitOfWork) :  Service<Rental>(unitOfWork)
{
    public override IResult Add(Rental item)
    {
        IResult result = new Result();
        
        var repository = UnitOfWork.GetRepository<Rental>();
        
        if (repository == null)
        {
            result.Success = false;
            result.Message = "Internal Server Error";
            return result;
        }
        
        UnitOfWork.Begin();
        repository.Insert(item);
        UnitOfWork.SaveChanges();
        UnitOfWork.Commit();
        
        result.Success = true;
        result.Message = "Address added successfully";
        return result;
    }

    public override IResult Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    public override IResult Update(Rental item)
    {
        throw new NotImplementedException();
    }

    public override Rental? GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public override ICollection<Rental>? GetAll()
    {
        throw new NotImplementedException();
    }
}