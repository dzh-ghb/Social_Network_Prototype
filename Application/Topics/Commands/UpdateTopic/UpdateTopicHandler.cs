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

        topic.Title = request.TopicDto.Title ?? topic.Title;
        topic.Summary = request.TopicDto.Summary ?? topic.Summary;
        topic.TopicType = request.TopicDto.TopicType ?? topic.TopicType;
        topic.Location = Location.Of(
            request.TopicDto.Location.City,
            request.TopicDto.Location.Street
        ) ?? topic.Location;
        topic.EventStart = request.TopicDto.EventStart;

        await dbContext.SaveChangesAsync(CancellationToken.None);

        return new UpdateTopicResult(topic.ToTopicResponseDto());
    }
}