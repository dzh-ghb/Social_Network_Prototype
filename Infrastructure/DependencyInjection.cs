namespace Infrastructure;

// метод расширения для регистрации сервиса с БД
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("SQLiteConnection");

        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlite(connectionString);
        });

        // регистрация контекста БД по интерфейсу
        services.AddScoped<IApplicationDbContext, ApplicationDbContext>();

        return services;
    }
}