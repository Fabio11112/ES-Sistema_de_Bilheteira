using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using SistemaDeBilheteira.Services.AuthenticationService.Models;

namespace SistemaDeBilheteira.Services.AuthenticationService.Validation;


public class UserInputValidator : IUserInputValidator
{
    public bool IsValidEmail(string email)
    {
        return new EmailAddressAttribute().IsValid(email);
    }

    public bool IsValidPassword(string password)
    {
        const string pattern = "^(?=.*[A-Za-z])(?=.*\\d)[A-Za-z\\d]{8,}$";
        return Regex.IsMatch(password, pattern);
    }
    
    public bool IsPasswordConfirmed(string password, string confirmPassword)
    {
        return password == confirmPassword;
    }

    public bool ValidateInput(UserRegisterModel model, IAuthResult result)
    {
        if (!IsValidEmail(model.Email))
        {
            result.Success = false;
            result.Message = "The email address is invalid.";
            return false;
        }

        if (!IsValidPassword(model.Password))
        {
            result.Success = false;
            result.Message = "The password is invalid.";
            return false;
        }

        if (!IsPasswordConfirmed(model.Password, model.ConfirmPassword))
        {
            result.Success = false;
            result.Message = "The password and confirmation password do not match.";
            return false;
        }
        return true;
    }
    
}