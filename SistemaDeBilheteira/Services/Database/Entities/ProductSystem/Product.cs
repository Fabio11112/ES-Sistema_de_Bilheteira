namespace SistemaDeBilheteira.Services.Database.Entities.ProductSystem;

public abstract class Product(double price, string movieId) : DbItem, IProduct
{
    public double Price { get; } = price;
    public string MovieId { get; } = movieId;
}