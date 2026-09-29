using Application.Exceptions;
using Domain.ValueObjects;

namespace Application.Topics;

// операции над топиками
public class TopicsService(IApplicationDbContext dbContext,
    ILogger<TopicsService> logger) : ITopicsService
{
    public async Task<TopicResponseDto> CreateTopicAsync(CreateTopicRequestDto dto)
    {
        Topic newTopic = Topic.Create(
            TopicId.Of(Guid.NewGuid()),
            dto.Title,
            dto.EventStart,
            dto.Summary,
            dto.TopicType,
            Location.Of(dto.Location.City, dto.Location.Street)
        );

        dbContext.Topics.Add(newTopic);
        await dbContext.SaveChangesAsync(CancellationToken.None);

        return newTopic.ToTopicResponseDto();
    }

    public async Task<List<TopicResponseDto>> GetTopicsAsync(CancellationToken ct)
    {
        try
        {
            for (int i = 1; i <= 3; i++)
            {
                ct.ThrowIfCancellationRequested();
                await Task.Delay(1000, ct);
                logger.LogInformation($">> {i} сек.");
            }

            var topics = await dbContext.Topics
                .AsNoTracking() // отключение отслеживания изменений (т.к. это операция чтения)
                .ToListAsync(ct);

            return topics.ToTopicResponseDtoList();
        }
        catch (System.Exception)
        {
            logger.LogWarning(">> Запрос отменен");
            return new List<TopicResponseDto>();
        }
    }

    public async Task<TopicResponseDto> GetTopicAsync(Guid id)
    {
        TopicId topicId = TopicId.Of(id);
        var result = await dbContext.Topics.FindAsync([topicId]);

        if (result is null)
        {
            throw new TopicNotFoundException(id);
        }

        return result.ToTopicResponseDto();
    }

    public Task<TopicResponseDto> UpdateTopicAsync(Guid id, UpdateTopicRequestDto dto)
    {
        throw new NotImplementedException();
    }

    public Task DeleteTopicAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}