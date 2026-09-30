namespace Domain.Abstractions;

// тип корневого элемента будущих сущностей
public abstract class Entity<T> : IEntity<T>
{
    // айди обязателен
    public required T Id { get; set; }

    // для реализации Soft Delete
    public bool DeleteFlag { get; set; } = default!;
    public DateTimeOffset? DeletedAt { get; set; } = default!;
}
