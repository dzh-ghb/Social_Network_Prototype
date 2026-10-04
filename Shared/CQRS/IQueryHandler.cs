namespace Shared.CQRS;

// обработчик запросов
public interface IQueryHandler<in TQuery, TResponse>
    : IRequestHandler<TQuery, TResponse>
    where TQuery : IQuery<TResponse> // ограничения
    where TResponse : notnull
{
}