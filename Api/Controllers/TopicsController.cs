using Application.Dtos;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicsController(ITopicsService topicsService) : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<TopicResponseDto>> CreateTopic(CreateTopicRequestDto dto)
        {
            return Ok(await topicsService.CreateTopicAsync(dto));
        }

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

        [HttpPut("{id}")]
        public async Task<ActionResult<TopicResponseDto>> UpdateTopic(Guid id, [FromBody] UpdateTopicRequestDto dto)
        {
            return Ok(await topicsService.UpdateTopicAsync(id, dto));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TopicResponseDto>> DeleteTopic(Guid id)
        {
            await topicsService.DeleteTopicAsync(id);

            return NoContent();
        }
    }
}
