namespace SistemaDeBilheteira.Services.Database;

/*
 * DbItem is an abstract class that implements the IDbElement interface.
 * It contains properties for the Id, CreatedAt, and UpdatedAt fields.
 * The Id is a unique identifier for the item, and the CreatedAt and UpdatedAt fields are used to track when the item was created and last updated.
 */
public abstract class DbItem : IDbElement
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}