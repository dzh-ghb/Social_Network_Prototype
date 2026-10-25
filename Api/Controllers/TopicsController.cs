namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicsController(IMediator mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<TopicResponseDto>> CreateTopic(CreateTopicRequestDto dto)
        {
            return Ok(null/*await topicsService.CreateTopicAsync(dto)*/);
        }

        [HttpGet]
        public async Task<ActionResult<List<TopicResponseDto>>> GetTopics(CancellationToken ct)
        {
            return Ok(await mediator.Send(new GetTopicsQuery(), ct));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TopicResponseDto>> GetTopic(Guid id)
        {
            return Ok(null/*await topicsService.GetTopicAsync(id)*/);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TopicResponseDto>> UpdateTopic(Guid id, [FromBody] UpdateTopicRequestDto dto)
        {
            return Ok(null/*await topicsService.UpdateTopicAsync(id, dto)*/);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TopicResponseDto>> DeleteTopic(Guid id)
        {
            // await topicsService.DeleteTopicAsync(id);
            // return NoContent();
            return Ok(null);
        }
    }
}
