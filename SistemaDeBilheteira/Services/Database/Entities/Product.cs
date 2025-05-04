using SistemaDeBilheteira.Services.Database;
using SistemaDeBilheteira.Services.Database.Entities;

public class Product : DbItem
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public ICollection<ShoppingCartItem> ShoppingCartItems { get; set; } = new List<ShoppingCartItem>();
}
