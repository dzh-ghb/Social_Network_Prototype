using Domain.ValueObjects;

namespace Application.Topics;

// операции над топиками
public interface ITopicsService
{
    Task<Topic> CreateTopicAsync(Topic topicRequestDto);
    Task<List<Topic>> GetTopicsAsync(CancellationToken ct);
    Task<Topic> GetTopicAsync(Guid id);
    Task<Topic> UpdateTopicAsync(Guid id, Topic topicRequestDto);
    Task DeleteTopicAsync(Guid id);
}