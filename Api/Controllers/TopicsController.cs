using Application.Dtos;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicsController(ITopicsService topicsService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<TopicResponseDto>>> GetTopics(CancellationToken ct)
        {
            return Ok(await topicsService.GetTopicsAsync(ct));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TopicResponseDto>> GetTopic(Guid id)
        {
            return Ok(await topicsService.GetTopicAsync(id));
        }
    }
}
