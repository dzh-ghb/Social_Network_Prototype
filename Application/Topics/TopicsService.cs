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
                .Where(t => !t.DeleteFlag)
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

        var topic = await dbContext.Topics.FindAsync([topicId]);

        if (topic is null || topic.DeleteFlag)
        {
            throw new TopicNotFoundException(id);
        }

        return topic.ToTopicResponseDto();
    }

    public async Task<TopicResponseDto> UpdateTopicAsync(Guid id, UpdateTopicRequestDto dto)
    {
        TopicId topicId = TopicId.Of(id);

        var topic = await dbContext.Topics.FindAsync([topicId]);

        if (topic is null || topic.DeleteFlag)
        {
            throw new TopicNotFoundException(id);
        }

        topic.Title = dto.Title ?? topic.Title;
        topic.Summary = dto.Summary ?? topic.Summary;
        topic.TopicType = dto.TopicType ?? topic.TopicType;
        topic.Location = Location.Of(
            dto.Location.City,
            dto.Location.Street
        ) ?? topic.Location;
        topic.EventStart = dto.EventStart;

        await dbContext.SaveChangesAsync(CancellationToken.None);

        return topic.ToTopicResponseDto();
    }

    public async Task DeleteTopicAsync(Guid id)
    {
        TopicId topicId = TopicId.Of(id);

        var topic = await dbContext.Topics.FindAsync([topicId]);

        if (topic is null || topic.DeleteFlag)
        {
            throw new TopicNotFoundException(id);
        }

        topic.DeleteFlag = true;
        topic.DeletedAt = DateTimeOffset.UtcNow;
        // dbContext.Topics.Remove(topic);

        await dbContext.SaveChangesAsync(CancellationToken.None);
    }
}