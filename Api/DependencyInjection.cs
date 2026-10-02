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

        // демо настройки CORS-политик для разрешения доступа к API (серверу) с определенных ресурсов
        services.AddCors(options =>
        {
            options.AddPolicy("react-policy", policy =>
            {
                policy
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .WithOrigins("http://localhost:3000");
            });
        });

        return services;
    }

    // конвейер обработки запросов
    public static WebApplication UseApiServices(
        this WebApplication app)
    {
        app.UseCors("react-policy");

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