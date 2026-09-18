namespace Domain.Abstractions;

interface IEntity<T> : IEntity
{
    public T Id { get; set; }
}

// вершина иерархии будущих сущностей
public interface IEntity
{

}