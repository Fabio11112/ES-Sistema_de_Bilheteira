
namespace SistemaDeBilheteira.Services.Database.Entities;

public class ShoppingCartItem : DbItem
{
    public string AppUserId { get; set; }
    public AppUser AppUser { get; set; } = null!;
    public Guid ProductId { get; set; }
    public Product Product { get; set; } = null!;
    public int Quantity { get; set; }
}
