namespace SistemaDeBilheteira.Services.Database.Entities.ProductSystem.Rental.RentalStates;


public class CancelledState : RentalState
{
    public CancelledState() => Name = "Cancelled";

    public override void Next(Rental rental)
    {
        // No further transition
    }

    public override void Cancel(Rental rental)
    {
        // Already cancelled
    }
}