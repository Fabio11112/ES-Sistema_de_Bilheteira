using Microsoft.EntityFrameworkCore;
using SistemaDeBilheteira.Services.Database.Entities.ShoppingCart;
using SistemaDeBilheteira.Services.Database.Entities.User;
using SistemaDeBilheteira.Services.IService;
using SistemaDeBilheteira.Services.IService.ServiceManager;

namespace SistemaDeBilheteira.Services.Database.Entities.PaymentSystem;

public class PurchaseSystem(IServiceManager serviceManager) : IPurchaseSystem
{
    private IService<ShoppingCartItem> CartItemService { get; } = serviceManager.GetService<ShoppingCartItem>();
    private IService<Purchase> PurchaseService { get; } = serviceManager.GetService<Purchase>();
    private IService<PurchaseItem> PurchaseItemService { get;  } = serviceManager.GetService<PurchaseItem>();
    private IService<PaymentMethod> PaymentMethodService { get; } = serviceManager.GetService<PaymentMethod>();

    public bool Pay(PaymentMethod paymentMethod, AppUser user, Address? address = null)
    {
        try
        {
            var items = GetShoppingCartItems(user);
            if(items == null || items.Count == 0)
                return false;
            
            var totalPrice = GetTotalPrice(items);
            
            if (paymentMethod.Balance < totalPrice)
                return false;
            
            paymentMethod.Balance -= totalPrice;
            PaymentMethodService.Update(paymentMethod);

            var purchase = AddPurchase(totalPrice, user, address);

            AddPurchaseItems(items, purchase);
            DeleteCartItems(items);

            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.StackTrace);
            return false;
        }

    }
    
    

    private ICollection<ShoppingCartItem>? GetShoppingCartItems(AppUser user)
    {
        return CartItemService.GetWithQuery(
            q =>
                q.Where(
                        i => i.AppUser == user)
                    .Include(i => i.Product));
        
    }

    private double GetTotalPrice(ICollection<ShoppingCartItem> items)
    {
        double totalPrice = 0;

        foreach (var item in items)
        {
            totalPrice += item.Product.Price * item.Quantity;
        }
        return totalPrice;
    }

    private Purchase AddPurchase(double totalPrice, AppUser user, Address? address)
    {
        Purchase purchase = new Purchase()
        {
            Amount = totalPrice,
            AppUserId = user.Id,
            Address = address,
        };

        PurchaseService.Add(purchase);
        return purchase;
    }

    private void AddPurchaseItems(ICollection<ShoppingCartItem> items, Purchase purchase)
    {
        foreach (var item in items)
        {
            var purchaseItem = new PurchaseItem()
            {
                ProductId = item.Product.Id,
                PurchaseId = purchase.Id,
                Quantity = item.Quantity,
            };

            PurchaseItemService.Add(purchaseItem);

        }
    }

    private void DeleteCartItems(ICollection<ShoppingCartItem> items)
    {
        foreach (var item in items)
        {
            CartItemService.Delete(item);
        }
    }
}