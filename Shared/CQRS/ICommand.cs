namespace Shared.CQRS;

// команда, возвращающая результат (общая абстракция)
public interface ICommand<out TResponse> : IRequest<TResponse>
{
}

// команда без возвращаемого результата
public interface ICommand : IRequest<Unit>
{
}