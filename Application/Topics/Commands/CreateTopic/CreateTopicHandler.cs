namespace Application.Topics.Commands.CreateTopic;

public class CreateTopicHandler(IApplicationDbContext dbContext)
    : ICommandHandler<CreateTopicCommand, CreateTopicResult>
{
    public async Task<CreateTopicResult> Handle(CreateTopicCommand request, CancellationToken cancellationToken)
    {
        var newTopic = CreateTopic(request.TopicDto);
        dbContext.Topics.Add(newTopic);
        await dbContext.SaveChangesAsync(CancellationToken.None);

        return new CreateTopicResult(newTopic.ToTopicResponseDto());
    }

    private Topic CreateTopic(CreateTopicRequestDto dto)
    {
        return Topic.Create(
            TopicId.Of(Guid.NewGuid()),
            dto.Title,
            dto.EventStart,
            dto.Summary,
            dto.TopicType,
            Location.Of(dto.Location.City, dto.Location.Street)
        );
    }
}