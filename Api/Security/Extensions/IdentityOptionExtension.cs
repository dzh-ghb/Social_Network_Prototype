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
            opt.User.RequireUniqueEmail = true;
        })
        .AddEntityFrameworkStores<ApplicationDbContext>();

        string secretKey = config["AuthSettings:SecretKey"]!;
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

        // настройка аутентификации через JWT-токен
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(opt =>
            {
                opt.TokenValidationParameters = new TokenValidationParameters // параметры валидации токена
                {
                    ValidateIssuerSigningKey = true, // проверка ключа подписи токена
                    IssuerSigningKey = key, // ключ для проверки подписи
                    ValidateLifetime = true, // проверка срока действия токена
                    ValidateIssuer = false, // отключение проверки издателя токена
                    ValidateAudience = false, // отключение проверки получателя токена
                    ClockSkew = TimeSpan.Zero // дельта валидности ключа 0 минут
                    // (по дефолту валидность токена с запасом ~5 минут)
                };
            });

        services.AddScoped<IJwtSecurityService, JwtSecurityService>();

        return services;
    }
}