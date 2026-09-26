namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicsController(ITopicsService topicsService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<Topic>>> GetTopics(CancellationToken ct)
        {
            return Ok(await topicsService.GetTopicsAsync(ct));
        }
    }
}
