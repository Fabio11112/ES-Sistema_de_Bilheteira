using SistemaDeBilheteira.Services.Database;
using SistemaDeBilheteira.Services.Database.Entities.ShoppingCart;


public abstract class Product : DbItem
{
    // public string Title { get; set; } = string.Empty;
    public double Price { get; set; }
    public string? MovieId { get; set; }

    public ICollection<ShoppingCartItem> ShoppingCartItems { get; set; } = new List<ShoppingCartItem>();

    public abstract string GetProductType();
    public abstract string PrintDetails();
}
