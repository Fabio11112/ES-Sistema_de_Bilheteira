using SistemaDeBilheteira.Services.Database.Entities;
using SistemaDeBilheteira.Services.Database.Entities.Payment;

public abstract class PaymentMethodBuilder
{
    protected string AppUserId { get; set; } = string.Empty;
    protected AppUser AppUser { get; set; } = null!;
    protected bool IsDefault { get; set; } = false;
    protected ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public PaymentMethodBuilder WithAppUserId(string appUserId)
    {
        AppUserId = appUserId;
        return this;
    }

    public PaymentMethodBuilder WithAppUser(AppUser appUser)
    {
        AppUser = appUser;
        return this;
    }

    public PaymentMethodBuilder WithIsDefault(bool isDefault)
    {
        IsDefault = isDefault;
        return this;
    }

    public PaymentMethodBuilder WithPayments(ICollection<Payment> payments)
    {
        Payments = payments;
        return this;
    }

    protected void SemiBuild(PaymentMethod paymentMethod)
    {
        paymentMethod.AppUserId = AppUserId;
        paymentMethod.AppUser = AppUser;
        paymentMethod.IsDefault = IsDefault;
        paymentMethod.Payments = Payments;
    }

    // public abstract PaymentMethod Build();
}