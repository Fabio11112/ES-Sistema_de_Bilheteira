namespace SistemaDeBilheteira.Services.Database.Entities.ProductSystem.Rental;

public abstract class RentalState
{
    public string Name { get; protected set; } = null!;

    public abstract void Next(Rental rental);
    public abstract void Cancel(Rental rental);
}
