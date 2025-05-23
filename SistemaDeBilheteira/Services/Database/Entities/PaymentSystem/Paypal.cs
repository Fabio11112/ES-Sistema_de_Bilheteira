namespace SistemaDeBilheteira.Services.Database.Entities.PaymentSystem;

public class Paypal : PaymentMethod
{
    public string PaypalEmail { get; set; } = string.Empty;
    public Guid PaypalTransactionId { get; set; } 
    public DateTime TransactionDate { get; set; }
    public override string PrintInformation()
    {
        return PaypalEmail;
    }
}