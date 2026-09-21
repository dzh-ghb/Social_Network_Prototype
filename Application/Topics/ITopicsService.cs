using Domain.ValueObjects;

namespace Application.Topics;

// операции над топиками
public interface ITopicsService
{
    Task<Topic> CreateTopicAsync(Topic topicRequestDto);
    Task<List<Topic>> GetTopicsAsync();
    Task<Topic> GetTopicAsync(Guid id);
    Task<Topic> UpdateTopicAsync(TopicId id, Topic topicRequestDto);
    Task DeleteTopicAsync(TopicId id);
}