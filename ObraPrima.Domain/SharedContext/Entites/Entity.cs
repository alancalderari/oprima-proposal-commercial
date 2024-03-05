namespace ObraPrima.Domain.SharedContext.Entites;

public abstract class Entity
{
    public int Id { get; set; }
    public bool Active { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
}