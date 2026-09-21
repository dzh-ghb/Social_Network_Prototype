using Application.Topics;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

// методы расширения для регистрации сервиса TopicsService в DI
public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        // регистрация сервиса по интерфейсу
        services.AddScoped<ITopicsService, TopicsService>();

        return services;
    }
}