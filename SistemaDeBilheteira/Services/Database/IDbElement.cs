namespace SistemaDeBilheteira.Services.Database;

public interface IDbElement : IDbItem
{
    Guid Id { get; set; }
}