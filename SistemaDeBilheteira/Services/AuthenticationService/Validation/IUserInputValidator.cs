using SistemaDeBilheteira.Services.AuthenticationService.Models;

namespace SistemaDeBilheteira.Services.AuthenticationService.Validation;

public interface IUserInputValidator
{
    public bool IsValidEmail(string email);
    public bool IsValidPassword(string password);
    public bool IsPasswordConfirmed(string password, string confirmPassword);

    public bool ValidateInput(UserRegisterModel model, IAuthResult result);
}