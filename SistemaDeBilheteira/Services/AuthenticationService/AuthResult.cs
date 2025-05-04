namespace SistemaDeBilheteira.Services.AuthenticationService;

public class Result : IResult
{
    public bool Success { get; set; }
    public string Message { get; set; }
}