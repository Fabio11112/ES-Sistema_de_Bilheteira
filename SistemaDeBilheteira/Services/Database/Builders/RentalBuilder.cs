using SistemaDeBilheteira.Services.Database.Entities.ProductSystem.Rental;

namespace SistemaDeBilheteira.Services.Database.Builders;

public class RentalBuilder
{
    private string MovieId { get; set; } = string.Empty;
    private double Price { get; set; }
    private DateTime StartDate { get; set; }
    private DateTime EndDate { get; set; }
    private RentalState? RentalState { get; set; }
    private string StateName { get; set; } = string.Empty;

    public RentalBuilder WithMovie(string movieId)
    {
        MovieId = movieId;
        return this;
    }

    public RentalBuilder WithPrice(double price)
    {
        Price = price;
        return this;
    }

    public RentalBuilder WithStartDate(DateTime startDate)
    {
        StartDate = startDate;
        return this;
    }

    public RentalBuilder WithEndDate(DateTime endDate)
    {
        EndDate = endDate;
        return this;
    }

    public RentalBuilder WithState(RentalState state)
    {
        RentalState = state;
        StateName = state.Name;
        return this;
    }

    public Rental Build()
    {
        return new Rental()
        {
            EndDate = EndDate,
            MovieId = MovieId,
            Price = Price,
            StartDate = StartDate,
            StateName = StateName,
            State = RentalState!
        };
        
    }
}
    
