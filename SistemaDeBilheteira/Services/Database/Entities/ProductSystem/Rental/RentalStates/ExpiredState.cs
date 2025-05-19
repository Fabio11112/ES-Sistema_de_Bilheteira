namespace SistemaDeBilheteira.Services.Database.Entities.ProductSystem.Rental.RentalStates;

public class ExpiredState : RentalState
{
    public ExpiredState() => Name = "Expired";

    public override void Next(Rental rental)
    {
        // No further transition
    }

    public override void Cancel(Rental rental)
    {
        // Already expired, can't cancel
    }
}