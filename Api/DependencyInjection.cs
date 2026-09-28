using Api.Exceptions.Handler;

namespace Api;

// методы расширения для регистрации сервисов и элементов конвейера запросов
public static class DependencyInjection
{
    // регистрация сервисов
    public static IServiceCollection AddApiServices(
        this IServiceCollection services/*,
        IConfiguration configuration*/)
    {
        services.AddExceptionHandler<CustomExceptionHandler>();
        services.AddControllers();
        services.AddOpenApi();

        return services;
    }

    // конвейер обработки запросов
    public static WebApplication UseApiServices(
        this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }

        app.UseExceptionHandler(options => { });
        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();

        return app;
    }
}