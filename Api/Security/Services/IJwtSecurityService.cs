namespace Api.Security.Services;

// сервис выдачи JWT-токенов
public interface IJwtSecurityService
{
    // в CustomIdentityUser информация, которая будет зашиваться в токен
    string CreateToken(CustomIdentityUser user);
}