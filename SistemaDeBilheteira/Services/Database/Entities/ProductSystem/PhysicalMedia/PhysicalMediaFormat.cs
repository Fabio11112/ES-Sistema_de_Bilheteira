namespace SistemaDeBilheteira.Services.Database.Entities.ProductSystem;

public class PhysicalMediaFormat : DbItem
{
    public string FormatName { get; set; } = string.Empty;
    public string Quality { get; set; } = string.Empty;

    public ICollection<PhysicalMedia> PhysicalMedias { get; set; } = new List<PhysicalMedia>();
}
