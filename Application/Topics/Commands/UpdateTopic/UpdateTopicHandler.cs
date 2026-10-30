namespace Application.Topics.Commands.UpdateTopic;

public class UpdateTopicHandler(IApplicationDbContext dbContext)
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

        topic.Update(request.TopicDto.Title, request.TopicDto.Summary, request.TopicDto.TopicType,
                        request.TopicDto.Location.City, request.TopicDto.Location.Street, request.TopicDto.EventStart);

        await dbContext.SaveChangesAsync(CancellationToken.None);

        return new UpdateTopicResult(topic.ToTopicResponseDto());
    }
}