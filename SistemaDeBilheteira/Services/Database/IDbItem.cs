namespace SistemaDeBilheteira.Services.Database;

public interface IDbItem
{
    Guid Id { get; set; }
    DateTime CreatedAt { get; set; }
    DateTime UpdatedAt { get; set; }
}