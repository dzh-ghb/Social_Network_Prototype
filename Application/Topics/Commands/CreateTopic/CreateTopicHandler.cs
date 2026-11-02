namespace Application.Topics.Commands.CreateTopic;

public class CreateTopicHandler(IApplicationDbContext dbContext, IMapper mapper)
    : ICommandHandler<CreateTopicCommand, CreateTopicResult>
{
    public async Task<CreateTopicResult> Handle(CreateTopicCommand request, CancellationToken cancellationToken)
    {
        var newTopic = mapper.Map<Topic>(request.TopicDto);

        dbContext.Topics.Add(newTopic);
        await dbContext.SaveChangesAsync(CancellationToken.None);

        return new CreateTopicResult(newTopic.ToTopicResponseDto());
    }
}