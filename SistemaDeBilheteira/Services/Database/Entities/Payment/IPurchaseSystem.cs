namespace SistemaDeBilheteira.Services.Database.Entities.Payment;

public interface IPurchaseSystem
{
    bool Pay(PaymentMethod paymentMethod, AppUser userId);
    
}