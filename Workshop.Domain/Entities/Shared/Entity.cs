
namespace Workshop.Domain.Entities.Shared;

public abstract class Entity : IEquatable<Entity>
{
    public Guid Id { get; set; }

    public Entity()
    {
        Id = Guid.NewGuid();
    }

    public bool Equals(Entity? other)
    {
        return other != null && Id == other.Id;
    }

    public override bool Equals(object? obj)
    {
        return obj != null && typeof(Entity).Equals(obj.GetType()) && Equals(obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id);
    }

    public static bool operator ==(Entity? left, Entity? right)
    {
        return EqualityComparer<Entity>.Default.Equals(left, right);
    }

    public static bool operator !=(Entity? left, Entity? right)
    {
        return !(left == right);
    }
}
