using SistemaDeBilheteira.Services.Database.Entities.ProductSystem.Rental.RentalStates;

namespace SistemaDeBilheteira.Services.Database.Entities.ProductSystem.Rental;

public static class StateFactory
{
    /**
        * Factory method to create a rental state based on the provided state name.
        * @param stateName The name of the rental state to create.
        * @return An instance of the specified rental state.
        * @throws InvalidOperationException if the state name is not recognized.
        */
    public static RentalState Create(string stateName)
    {
        return stateName switch
        {
            "Requested" => new RequestedState(),
            "Active" => new ActiveState(),
            "Expired" => new ExpiredState(),
            "Cancelled" => new CancelledState(),
            _ => throw new InvalidOperationException("Unknown rental state")
        };
    }
}
