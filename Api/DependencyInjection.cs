namespace Api;

// методы расширения для регистрации сервисов и элементов конвейера запросов
public static class DependencyInjection
{
    public static IServiceCollection AddApiServices(
        this IServiceCollection services/*,
        IConfiguration configuration*/)
    {
        services.AddControllers();
        services.AddOpenApi();

        return services;
    }

    public static WebApplication UseApiServices(
        this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        return app;
    }
}