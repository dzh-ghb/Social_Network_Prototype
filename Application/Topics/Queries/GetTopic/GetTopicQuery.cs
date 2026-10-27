namespace Application.Topics.Queries.GetTopic;

public record GetTopicQuery(Guid Id) : IQuery<GetTopicResult>;

public record GetTopicResult(TopicResponseDto Topic);