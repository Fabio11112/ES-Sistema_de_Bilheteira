using System.Collections.Generic;
using System.Linq;
using SistemaDeBilheteira.Services.Database.Entities;
using SistemaDeBilheteira.Services.Database.UnitOfWork;
using SistemaDeBilheteira.Services.Database.Repositories;

public class ShoppingCartService : IShoppingCartService
{
    private readonly IRepository<ShoppingCartItem> _shoppingCartRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ShoppingCartService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _shoppingCartRepository = _unitOfWork.GetRepository<ShoppingCartItem>();
    }

    // Add a product to the cart
    public void AddItemToCart(String userId, Guid productId, int quantity = 1)
    {
        var existingItem = _shoppingCartRepository
            .GetAll()
            .FirstOrDefault(i => i.AppUserId == userId && i.ProductId == productId);

        if (existingItem != null)
        {
            existingItem.Quantity += quantity;
            _shoppingCartRepository.Update(existingItem);
        }
        else
        {
            var item = new ShoppingCartItem
            {
                AppUserId = userId,
                ProductId = productId,
                Quantity = quantity
            };
            _shoppingCartRepository.Insert(item);
        }

        _unitOfWork.SaveChanges();
    }

    // Remove a product from the cart
    public void RemoveItemFromCart(String userId, Guid productId)
    {
        var item = _shoppingCartRepository
            .GetAll()
            .FirstOrDefault(i => i.AppUserId == userId && i.ProductId == productId);

        if (item != null)
        {
            _shoppingCartRepository.Delete(item);
            _unitOfWork.SaveChanges();
        }
    }

    // Obtain all items in the cart
    public List<ShoppingCartItem> GetCartItems(String userId)
    {
        return _shoppingCartRepository
            .GetAll()
            .Where(i => i.AppUserId == userId)
            .ToList();
    }

    // Clear the cart completely
    public void ClearCart(String userId)
    {
        var items = _shoppingCartRepository
            .GetAll()
            .Where(i => i.AppUserId == userId)
            .ToList();

        foreach (var item in items)
        {
            _shoppingCartRepository.Delete(item);
        }

        _unitOfWork.SaveChanges();
    }

    // Update the quantity of a product in the cart
    public void UpdateItemQuantity(String userId, Guid productId, int newQuantity)
    {
        var item = _shoppingCartRepository
            .GetAll()
            .FirstOrDefault(i => i.AppUserId == userId && i.ProductId == productId);

        if (item != null)
        {
            item.Quantity = newQuantity;
            _shoppingCartRepository.Update(item);
            _unitOfWork.SaveChanges();
        }
    }

    // Add a hardcoded item to the cart (for testing/demo)
    public void AddTestCartItem()
    {
        String userId = "1";
        Guid productId = Guid.NewGuid(); // Simulate a product ID
        int quantity = 1;

        var item = new ShoppingCartItem
        {
            AppUserId = userId,
            ProductId = productId,
            Quantity = quantity
        };

        _shoppingCartRepository.Insert(item);
        _unitOfWork.SaveChanges();
    }
}
