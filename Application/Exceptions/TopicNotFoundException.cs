namespace Application.Exceptions;

public class TopicNotFoundException : NotFoundException
{
    public TopicNotFoundException(string message) : base(message)
    {
    }

    public TopicNotFoundException(Guid id) : base($"Топик с id '{id}' не найден")
    {
    }
}