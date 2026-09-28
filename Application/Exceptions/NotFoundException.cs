namespace Application.Exceptions;

// доп. иерархия исключений (кастомные исключения)
public class NotFoundException : Exception
{
    public NotFoundException(string message) : base(message)
    {
    }
}