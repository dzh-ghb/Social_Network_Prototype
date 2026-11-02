namespace Shared.CQRS;

// обработчик команд (с входными и возвращаемыми данными)
public interface ICommandHandler<in TCommand, TResponse>
    : IRequestHandler<TCommand, TResponse>
    where TCommand : ICommand<TResponse> // ограничения
    where TResponse : notnull
{
}

// обработчик команд (с входными и БЕЗ возвращаемых данных)
public interface ICommandHandler<in TCommand>
    : ICommandHandler<TCommand, Unit>
    where TCommand : ICommand<Unit>
{
}