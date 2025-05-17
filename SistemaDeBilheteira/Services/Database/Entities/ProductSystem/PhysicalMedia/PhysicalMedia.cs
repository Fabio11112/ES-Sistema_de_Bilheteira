namespace SistemaDeBilheteira.Services.Database.Entities.ProductSystem;

public class PhysicalMedia : Product
{
    public string Resolution { get; set; } = string.Empty;

    public Guid FormatId { get; set; }
    public PhysicalMediaFormat Format { get; set; } = null!;
}
;
