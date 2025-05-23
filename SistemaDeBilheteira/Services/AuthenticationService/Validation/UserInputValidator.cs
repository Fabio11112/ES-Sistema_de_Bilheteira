using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using SistemaDeBilheteira.Services.AuthenticationService.Models;

namespace SistemaDeBilheteira.Services.AuthenticationService.Validation;


public class UserInputValidator : IUserInputValidator
{
    // This class is responsible for validating user input during registration.
    public bool IsValidEmail(string email)
    {
        return new EmailAddressAttribute().IsValid(email);
    }

    // Password must be at least 8 characters long, contain at least one letter and one number
    public bool IsValidPassword(string password)
    {
        const string pattern = "^(?=.*[A-Za-z])(?=.*\\d)[A-Za-z\\d]{8,}$";
        return Regex.IsMatch(password, pattern);
    }
    
    // Check if the password and confirmation password match
    public bool IsPasswordConfirmed(string password, string confirmPassword)
    {
        return password == confirmPassword;
    }

    // Validate the user input and set the result accordingly
    public bool ValidateInput(UserRegisterModel model, IResult result)
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