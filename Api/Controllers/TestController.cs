namespace Api.Controllers;

[Authorize] // требование авторизации на уровне контроллера
[ApiController]
[Route("api/[controller]")]
public class TestController : ControllerBase
{
    // [Authorize]
    [HttpGet("test1")]
    public async Task<IResult> test1()
    {
        await Task.CompletedTask;
        return Results.Ok(new { result = "test1 ok" });
    }

    [AllowAnonymous] // исключение (открытый эндпоинт)
    [HttpGet("test2")]
    public async Task<IResult> test2()
    {
        await Task.CompletedTask;
        return Results.Ok(new { result = "test2 ok" });
    }
}