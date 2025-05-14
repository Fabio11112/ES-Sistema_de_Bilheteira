using System.ComponentModel.DataAnnotations;

namespace SistemaDeBilheteira.Services.AuthenticationService.Models;

public class AddressModel : IModel
{
    [Required]
    public string StreetLine1 { get; set; } = string.Empty;
    public string? StreetLine2 { get; set; }
    [Required]
    public string City { get; set; } = string.Empty;
    [Required]
    public string State { get; set; } = string.Empty;
    [Required]
    public string ZipCode { get; set; } = string.Empty;
    [Required]
    public string Country { get; set; } = string.Empty;
}