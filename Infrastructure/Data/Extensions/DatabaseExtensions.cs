using Infrastructure.Data.DataBaseContext;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Data.Extensions;

// метод расширения с логикой получения зарегистрированных сервисов
// и обращением к dbContext (для применения миграций и добавления дефолтных данных)
public static class DatabaseExtensions
{
    public static async Task InitializeDatabaseAsync(this WebApplication app)
    {
        using IServiceScope scope = app.Services.CreateScope();
        var dbContext = scope
            .ServiceProvider
            .GetRequiredService<ApplicationDbContext>();

        dbContext.Database.MigrateAsync().GetAwaiter().GetResult();

        await SeedData(dbContext);
    }

    // метод наполнения данными (общий)
    private static async Task SeedData(ApplicationDbContext dbContext)
    {
        await SeedTopicsAsync(dbContext);
    }

    // метод наполнения топиками
    private static async Task SeedTopicsAsync(ApplicationDbContext dbContext)
    {
        // если таблицы топиков нет/пустая
        if (!await dbContext.Topics.AnyAsync())
        {
            await dbContext.Topics.AddRangeAsync(InitialData.Topics);
            await dbContext.SaveChangesAsync();
        }
    }
}