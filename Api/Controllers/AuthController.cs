namespace Api.Controllers;

[AllowAnonymous]
[ApiController]
[Route("api/[controller]")]
public class AuthController(UserManager<CustomIdentityUser> manager,
    IJwtSecurityService jwtSecurityService) : ControllerBase
{
    [HttpPost("login")]
    public async Task<IResult> Login(LoginRequest dto)
    {
        var user = await manager.FindByEmailAsync(dto.Email);

        if (user is null)
        {
            return Results.Unauthorized();
        }

        var result = await manager.CheckPasswordAsync(user, dto.Password);

        if (result)
        {
            var response = new IdentityUserResponseDto(
                user.UserName!, user.Email!, jwtSecurityService.CreateToken(user)
            );

            return Results.Ok(new { result = response });
        }

        return Results.Unauthorized();
    }

    [HttpPost("register")]
    public async Task<IResult> Register(RegisterUserRequestDto dto)
    {
        if (await manager.Users.AnyAsync(u => u.UserName == dto.UserName))
        {
            return Results.BadRequest("Username занят");
        }

        if (await manager.Users.AnyAsync(u => u.Email == dto.Email))
        {
            return Results.BadRequest("Email занят");
        }

        var user = new CustomIdentityUser
        {
            FullName = dto.FullName,
            Email = dto.Email,
            UserName = dto.UserName,
            About = String.Empty
        };

        var result = await manager.CreateAsync(user, dto.Password!);

        if (result.Succeeded)
        {
            var response = new IdentityUserResponseDto(
                user.UserName!, user.Email!, jwtSecurityService.CreateToken(user)
            );

            return Results.Ok(new { result = response });
        }

        return Results.BadRequest(result.Errors);
    }
}