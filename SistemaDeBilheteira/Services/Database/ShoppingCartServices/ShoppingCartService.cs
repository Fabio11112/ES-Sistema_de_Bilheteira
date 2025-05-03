using System.Collections.Generic;
using System.Linq;
using SistemaDeBilheteira.Services.Database.Context;
using SistemaDeBilheteira.Services.Database.Entities;

public class ShoppingCartService
{
    private readonly SistemaDeBilheteiraContext _context;

    public ShoppingCartService(SistemaDeBilheteiraContext context)
    {
        _context = context;
    }

    // Add a product to the cart
    public void AddItemToCart(int userId, int productId, int quantity = 1)
    {
        var existingItem = _context.ShoppingCartItems
            .FirstOrDefault(i => i.AppUserId == userId && i.ProductId == productId);

        if (existingItem != null)
        {
            existingItem.Quantity += quantity;
        }
        else
        {
            var item = new ShoppingCartItem
            {
                AppUserId = userId,
                ProductId = productId,
                Quantity = quantity
            };
            _context.ShoppingCartItems.Add(item);
        }

        _context.SaveChanges();
    }

    // Remove a product from the cart
    public void RemoveItemFromCart(int userId, int productId)
    {
        var item = _context.ShoppingCartItems
            .FirstOrDefault(i => i.AppUserId == userId && i.ProductId == productId);

        if (item != null)
        {
            _context.ShoppingCartItems.Remove(item);
            _context.SaveChanges();
        }
    }

    // Obtain all items in the cart
    public List<ShoppingCartItem> GetCartItems(int userId)
    {
        return _context.ShoppingCartItems
            .Where(i => i.AppUserId == userId)
            .ToList();
    }

    // Clear the cart completely
    public void ClearCart(int userId)
    {
        var items = _context.ShoppingCartItems
            .Where(i => i.AppUserId == userId);

        _context.ShoppingCartItems.RemoveRange(items);
        _context.SaveChanges();
    }

    // Actually update the quantity of a product in the cart
    public void UpdateItemQuantity(int userId, int productId, int newQuantity)
    {
        var item = _context.ShoppingCartItems
            .FirstOrDefault(i => i.AppUserId == userId && i.ProductId == productId);

        if (item != null)
        {
            item.Quantity = newQuantity;
            _context.SaveChanges();
        }
    }
       public void AddTestCartItem()
    {
        // Cambia estos valores por IDs válidos que existan en tu base de datos
        int userId = 1;
        int productId = 356;
        int quantity = 1;

        using (var context = new SistemaDeBilheteiraContext())
        {
            var item = new ShoppingCartItem
            {
                AppUserId = userId,
                ProductId = productId,
                Quantity = quantity
            };
            context.ShoppingCartItems.Add(item);
            context.SaveChanges();
        }
    }

}
