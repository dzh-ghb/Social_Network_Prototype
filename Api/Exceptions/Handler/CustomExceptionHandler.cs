using Application.Exceptions;
using Microsoft.AspNetCore.Diagnostics;

namespace Api.Exceptions.Handler;

// глобальный обработчик исключений из HTTP-контекста
public class CustomExceptionHandler(ILogger<CustomExceptionHandler> logger) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        // логирование ошибки
        logger.LogWarning("Обработанное исключение: '{message}', время: {time}", exception.Message, DateTime.UtcNow);

        (string Title, string Detail, int StatusCode) details = exception switch
        {
            NotFoundException => (
                exception.GetType().Name,
                exception.Message,
                httpContext.Response.StatusCode = StatusCodes.Status404NotFound
            ),
            _ => ( // реагирование на остальные типы исключений
                exception.GetType().Name,
                exception.Message,
                httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError
            )
        };

        var problemDetails = new ProblemDetails
        {
            Title = details.Title,
            Detail = details.Detail,
            Status = details.StatusCode,
            Instance = httpContext.Request.Path // маршрут, где возникла ошибка
        };

        problemDetails.Extensions.Add("traceId", httpContext.TraceIdentifier); // уникальный идентификатор запроса

        await httpContext
            .Response
            .WriteAsJsonAsync(problemDetails, cancellationToken);

        return true;
    }
}