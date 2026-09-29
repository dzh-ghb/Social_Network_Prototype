namespace Application.Topics;

// операции над топиками
public interface ITopicsService
{
    Task<TopicResponseDto> CreateTopicAsync(CreateTopicRequestDto dto);
    Task<List<TopicResponseDto>> GetTopicsAsync(CancellationToken ct);
    Task<TopicResponseDto> GetTopicAsync(Guid id);
    Task<TopicResponseDto> UpdateTopicAsync(Guid id, UpdateTopicRequestDto dto);
    Task DeleteTopicAsync(Guid id);
}