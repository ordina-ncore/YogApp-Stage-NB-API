namespace YogApp.Domain.Shared;

public abstract class EntityBase
{
    public Guid Id { get; init; }
    public bool IsDeleted { get; set; }
}
