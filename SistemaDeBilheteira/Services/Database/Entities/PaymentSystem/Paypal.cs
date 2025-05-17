namespace SistemaDeBilheteira.Services.Database.Entities.PaymentSystem;

public class Paypal : PaymentMethod
{
    public string PaypalEmail { get; set; } = string.Empty;
    public string PaypalTransactionId { get; set; } = string.Empty;
    public DateTime TransactionDate { get; set; }
}