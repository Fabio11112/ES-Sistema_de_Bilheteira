using SistemaDeBilheteira.Services.Database.Entities.Payment;

public class Card : PaymentMethod
{
    public string CardHolderName { get; set; }
    public string CardNumber { get; set; }
    public String Cvv { get; set; }
    public DateTime ExpirationDate { get; set; }
    public string Brand { get; set; }
}