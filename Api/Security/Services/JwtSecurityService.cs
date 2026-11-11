namespace Api.Security.Services;

public class JwtSecurityService(IConfiguration configuration) : IJwtSecurityService
{
    public string CreateToken(CustomIdentityUser user)
    {
        string secretKey = configuration["AuthSettings:SecretKey"]!;

        // перечень утверждений о пользователе
        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id),
            new Claim(JwtRegisteredClaimNames.Name, user.UserName!),
            new Claim(JwtRegisteredClaimNames.Email, user.Email!),
            new Claim("is_premium", "true")
        };

        // симметричный ключ безопасности
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

        // учетные данные для подписи с использованием алгоритма шифрования
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

        // обработчик JWT-токенов
        var tokenHandler = new JsonWebTokenHandler();

        // параметры JWT-токена
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            SigningCredentials = creds, // учетные данные для подписи токена
            Subject = new ClaimsIdentity(claims), // перечень утверждений
            IssuedAt = DateTime.UtcNow, // время создания токена
            NotBefore = DateTime.UtcNow.AddMinutes(0), // время начала действия токена
            Expires = DateTime.UtcNow.AddMinutes(10) // время окончания действия токена
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);

        return token;
    }
}