using System.ComponentModel.DataAnnotations;

namespace SistemaDeBilheteira.Services.AuthenticationService.Models;

public class InfoUserModel : IModel
{
    [Required]
    public string EmailAddress { get; set; } = string.Empty;
    [Required]
    public string OldPassword { get; set; } = string.Empty;
    [Required]
    public string NewPassword { get; set; } = string.Empty;
    [Required]
    public string ConfirmPassword { get; set; } = string.Empty;
}