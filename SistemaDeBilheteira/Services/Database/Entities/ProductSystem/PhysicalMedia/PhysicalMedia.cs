namespace SistemaDeBilheteira.Services.Database.Entities.ProductSystem.PhysicalMedia;

public class PhysicalMedia : Product
{
    public PhysicalMediaFormat Format { get; set; } = null!;
    public Guid FormatId { get; set; }
}
;
