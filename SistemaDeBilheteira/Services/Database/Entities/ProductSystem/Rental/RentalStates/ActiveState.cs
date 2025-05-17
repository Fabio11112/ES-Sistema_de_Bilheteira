namespace SistemaDeBilheteira.Services.Database.Entities.ProductSystem.Rental.RentalStates;

public class ActiveState : RentalState
{
    public ActiveState() => Name = "Active";

    public override void Next(Rental rental)
    {
        if (DateTime.UtcNow > rental.EndDate)
        {
            rental.State = new ExpiredState();
            rental.StateName = rental.State.Name;
        }
    }

    public override void Cancel(Rental rental)
    {
        rental.State = new CancelledState();
        rental.StateName = rental.State.Name;
    }
}