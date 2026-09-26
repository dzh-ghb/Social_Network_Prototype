using Domain.ModelsDto;
using Domain.ValueObjects;

namespace Application.Topics;

// операции над топиками
public class TopicsService(IApplicationDbContext dbContext,
    ILogger<TopicsService> logger) : ITopicsService
{
    public Task<TopicResponseDto> CreateTopicAsync(CreateTopicRequestDto topicRequestDto)
    {
        throw new NotImplementedException();
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

            var topicsResponse = new List<TopicResponseDto>();

            foreach (var topic in topics)
            {
                topicsResponse.Add(
                    new TopicResponseDto(
                        topic.Id.Value,
                        topic.Title,
                        topic.Summary,
                        topic.TopicType,
                        new LocationDto(topic.Location.City, topic.Location.Street),
                        topic.EventStart
                    )
                );
            }

            return topicsResponse;
        }
        catch (System.Exception)
        {
            logger.LogWarning(">> Запрос отменен");
            return new List<TopicResponseDto>();
        }
    }

    public Task<TopicResponseDto> GetTopicAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<TopicResponseDto> UpdateTopicAsync(Guid id, UpdateTopicRequestDto topicRequestDto)
    {
        throw new NotImplementedException();
    }

    public Task DeleteTopicAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}