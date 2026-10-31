namespace Application.Topics.Commands.UpdateTopic;

public class UpdateTopicHandler(IApplicationDbContext dbContext, IMapper mapper)
    : ICommandHandler<UpdateTopicCommand, UpdateTopicResult>
{
    public async Task<UpdateTopicResult> Handle(UpdateTopicCommand request, CancellationToken cancellationToken)
    {
        TopicId topicId = TopicId.Of(request.Id);

        var topic = await dbContext.Topics.FindAsync([topicId]);

        if (topic is null || topic.DeleteFlag)
        {
            throw new TopicNotFoundException(request.Id);
        }

        mapper.Map(request.TopicDto, topic);

        await dbContext.SaveChangesAsync(CancellationToken.None);

        return new UpdateTopicResult(topic.ToTopicResponseDto());
    }
}