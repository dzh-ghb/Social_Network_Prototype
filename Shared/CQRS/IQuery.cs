namespace Shared.CQRS;

// запрос, всегда возвращает результат (общая абстракция)
public interface IQuery<out TResponse> : IRequest<TResponse>
{
}