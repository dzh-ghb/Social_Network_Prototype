namespace Application.Topics.Old;

// операции над топиками
[Obsolete("Сервис устарел", true)] // устаревший
public interface ITopicsService
{
    Task<TopicResponseDto> CreateTopicAsync(CreateTopicRequestDto dto);
    Task<List<TopicResponseDto>> GetTopicsAsync(CancellationToken ct);
    Task<TopicResponseDto> GetTopicAsync(Guid id);
    Task<TopicResponseDto> UpdateTopicAsync(Guid id, UpdateTopicRequestDto dto);
    Task DeleteTopicAsync(Guid id);
}