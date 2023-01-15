namespace Workshop.Domain.Entities;

public abstract class Entity
{
    public Guid Id { get; set; }

    public Entity() {
        Id = new Guid();
    }
}
