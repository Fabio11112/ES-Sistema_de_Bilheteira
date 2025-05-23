namespace SistemaDeBilheteira.Services.Database;

public interface IDbItem
{
    DateTime CreatedAt { get; set; }
    DateTime UpdatedAt { get; set; }
}