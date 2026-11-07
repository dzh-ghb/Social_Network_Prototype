using Domain.Security;
using Infrastructure.Data.DataBaseContext;

namespace Api.Security.Extensions;

// метод расширения для настройки контекста БД (требования к пароля юзера)
public static class IdentityOptionExtension
{
    public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddIdentityCore<CustomIdentityUser>(opt =>
        {
            opt.Password.RequireDigit = false;
            opt.Password.RequiredLength = 1;
            opt.Password.RequireLowercase = false;
            opt.Password.RequireUppercase = false;
            opt.Password.RequireNonAlphanumeric = false;
        })
        .AddEntityFrameworkStores<ApplicationDbContext>();

        services.AddAuthentication();

        return services;
    }
}