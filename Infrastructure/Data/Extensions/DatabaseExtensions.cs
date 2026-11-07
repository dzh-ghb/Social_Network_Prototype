using Domain.Security;
using Microsoft.AspNetCore.Identity;

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

        var manager = scope
            .ServiceProvider
            .GetRequiredService<UserManager<CustomIdentityUser>>();

        dbContext.Database.MigrateAsync().GetAwaiter().GetResult();

        await SeedData(dbContext, manager);
    }

    // метод наполнения данными (общий)
    private static async Task SeedData(ApplicationDbContext dbContext,
        UserManager<CustomIdentityUser> manager)
    {
        await SeedTopicsAsync(dbContext);
        await SeedIdentityUsersAsync(manager);
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

    // наполнение тестовыми юзерами
    private static async Task SeedIdentityUsersAsync(UserManager<CustomIdentityUser> manager)
    {
        if (!manager.Users.Any())
        {
            foreach (var user in InitialData.IdentityUsers)
            {
                await manager.CreateAsync(user, "1111");
            }
        }
    }
}