namespace Application.Topics.Queries.GetTopic;

public class GetTopicHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetTopicQuery, GetTopicResult>
{
    public async Task<GetTopicResult> Handle(GetTopicQuery request, CancellationToken cancellationToken)
    {
        TopicId topicId = TopicId.Of(request.Id);

        var topic = await dbContext.Topics.FindAsync([topicId], cancellationToken);

        if (topic is null || topic.DeleteFlag)
        {
            throw new TopicNotFoundException(request.Id);
        }

        return new GetTopicResult(topic.ToTopicResponseDto());
    }
}