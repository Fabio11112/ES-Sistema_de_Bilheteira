namespace SistemaDeBilheteira.Services.Database.Entities.ProductSystem.PhysicalMedia;

public class PhysicalMediaFormat : DbItem
{
    public string FormatName { get; set; } = string.Empty;
    public string Quality { get; set; } = string.Empty;
    
    public string Emoji { get; set; } = string.Empty;
}
