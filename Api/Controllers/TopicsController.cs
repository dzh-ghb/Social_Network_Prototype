namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicsController(IMediator mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<IResult> CreateTopic(CreateTopicRequestDto dto, CancellationToken ct)
        {
            var response = await mediator.Send(new CreateTopicCommand(dto), ct);
            return Results.Created($"/topics/{response.Topic.Id}", response.Topic);
        }

        [HttpGet]
        public async Task<IResult> GetTopics(CancellationToken ct)
        {
            return Results.Ok(await mediator.Send(new GetTopicsQuery(), ct));
        }

        [HttpGet("{id}")]
        public async Task<IResult> GetTopic(Guid id, CancellationToken ct)
        {
            return Results.Ok(await mediator.Send(new GetTopicQuery(id), ct));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TopicResponseDto>> UpdateTopic(Guid id, [FromBody] UpdateTopicRequestDto dto)
        {
            return Ok(null/*await topicsService.UpdateTopicAsync(id, dto)*/);
        }

        [HttpDelete("{id}")]
        public async Task<IResult> DeleteTopic(Guid id, CancellationToken ct)
        {
            return Results.Ok(await mediator.Send(new DeleteTopicCommand(id), ct));
        }
    }
}
