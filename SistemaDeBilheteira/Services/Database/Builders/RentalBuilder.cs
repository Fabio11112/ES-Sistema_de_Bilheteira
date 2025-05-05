using SistemaDeBilheteira.Services.Database.Entities.ProductSystem;

namespace SistemaDeBilheteira.Services.Database.Builders;

public class RentalBuilder
{
    public double Price { get; set; } 
    public string? MovieId { get; set; } 
    public DateTime startDate { get; set; } 
    public DateTime endDate { get; set; }


    public RentalBuilder WithPrice(double price)
    {
        Price = price;
        return this;
    }

    public RentalBuilder WithMovie(string movieId)
    {
        MovieId = movieId;
        return this;
    }

    public RentalBuilder WithStartDate(DateTime startDate)
    {
        this.startDate = startDate;
        return this;
    }

    public RentalBuilder WithEndDate(DateTime endDate)
    {
        this.endDate = endDate;
        return this;
    }

    public Rental? Build()
    {
        if (Price == 0 || MovieId == null || MovieId.Length == 0 || startDate == null || endDate == null)
        {
            return null;
        }

        var rental = new Rental();
        rental.Price = Price;
        rental.MovieId = MovieId;
        rental.startDate = startDate;
        rental.endDate = endDate;
        return rental;
    }
}