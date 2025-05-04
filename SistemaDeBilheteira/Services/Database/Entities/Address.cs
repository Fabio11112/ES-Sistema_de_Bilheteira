namespace SistemaDeBilheteira.Services.Database.Entities;

public class Address : DbItem
{
    public  string StreetLine1 { get; set; }
    public string? StreetLine2 { get; set; }
    public  string City { get; set; }
    public  string State { get; set; }
    public  string ZipCode { get; set; }
    public  string Country { get; set; }
    public bool IsDefault { get; set; }
    public string AppUserId { get; set; }
    public AppUser AppUser { get; set; }
    
}