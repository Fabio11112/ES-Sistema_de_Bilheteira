namespace SistemaDeBilheteira.Services.Database.Entities.ProductSystem;

public abstract class Product : DbItem, IProduct
{
    public double Price { get; set; } 
    public string MovieId { get; set; } 
}