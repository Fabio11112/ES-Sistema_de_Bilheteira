namespace SistemaDeBilheteira.Services.Database.Entities.ProductSystem;

public class Rental(double price, string movieId, DateTime starDate, DateTime endDate) : Product(price, movieId)
{
    public DateTime startDate { get; } = starDate;
    public DateTime endDate { get; } = endDate;
}