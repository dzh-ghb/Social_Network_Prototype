using Domain.ModelsDto;

namespace Application.Topics;

// операции над топиками
public interface ITopicsService
{
    Task<TopicResponseDto> CreateTopicAsync(CreateTopicRequestDto topicRequestDto);
    Task<List<TopicResponseDto>> GetTopicsAsync(CancellationToken ct);
    Task<TopicResponseDto> GetTopicAsync(Guid id);
    Task<TopicResponseDto> UpdateTopicAsync(Guid id, UpdateTopicRequestDto topicRequestDto);
    Task DeleteTopicAsync(Guid id);
}