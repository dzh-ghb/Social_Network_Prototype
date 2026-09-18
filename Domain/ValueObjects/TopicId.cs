namespace Domain.ValueObjects;

// описание идентификатора топика
public record TopicId
{
    public Guid Value { get; }

    private TopicId(Guid value)
    {
        this.Value = value;
    }

    // фабрика для создания айди
    public static TopicId Of(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new DomainException("TopicId не может быть пустым");
        }

        return new TopicId(value);
    }
}