﻿namespace Workshop.Domain.Entities;

public abstract class Entity : IEquatable<Entity>
{
    public Guid Id { get; set; }

    public Entity() {
        Id = Guid.NewGuid();
    }

    public bool Equals(Entity? other)
    {
        return Id == other.Id;
    }
}
