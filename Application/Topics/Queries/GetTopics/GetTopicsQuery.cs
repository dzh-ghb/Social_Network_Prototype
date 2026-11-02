namespace Application.Topics.Queries.GetTopics;

// модель запроса
public record GetTopicsQuery : IQuery<GetTopicsResult>;

// модель результата запроса
public record GetTopicsResult(List<TopicResponseDto> Topics);