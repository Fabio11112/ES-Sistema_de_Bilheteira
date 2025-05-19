using SistemaDeBilheteira.Services.Database.Entities.ProductSystem.Rental;

namespace SistemaDeBilheteira.Services.Database.Entities.ProductSystem.Rental.RentalStates{

public class RequestedState : RentalState
{
    public RequestedState() => Name = "Requested";

    /**
        * Transition to the next state
        * @param rental The rental object
        */
    public override void Next(Rental rental)
    {
        rental.State = new ActiveState();
        rental.StateName = rental.State.Name;
    }


    /**
        * Cancel the rental
        * @param rental The rental object
        */
    public override void Cancel(Rental rental)
    {
        rental.State = new CancelledState();
        rental.StateName = rental.State.Name;
    }
}
}