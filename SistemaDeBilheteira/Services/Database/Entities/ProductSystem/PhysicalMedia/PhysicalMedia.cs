namespace SistemaDeBilheteira.Services.Database.Entities.ProductSystem.PhysicalMedia;

public class PhysicalMedia : Product
{
    public PhysicalMediaFormat Format { get; set; } = null!;
    public Guid FormatId { get; set; }
    public override string GetProductType()
    {
        return Format.FormatName;
    }

    public override string PrintDetails()
    {
        return $"Film in {Format.FormatName}";
    }
}
;
