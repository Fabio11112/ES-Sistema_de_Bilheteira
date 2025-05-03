namespace SistemaDeBilheteira.Services.Database.Entities;

public class Address : DbItem
{
    public required string StreetLine1 { get; set; }
    public string? StreetLine2 { get; set; }
    public required string City { get; set; }
    public required string State { get; set; }
    public required string ZipCode { get; set; }
    public required string Country { get; set; }
    public required bool IsDefault { get; set; }
    public string AppUserId { get; set; }
    public AppUser AppUser { get; set; }
    
}