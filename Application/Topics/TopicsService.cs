using Application.Data.DataBaseContext;
using Domain.ValueObjects;
using Microsoft.Extensions.Logging;

namespace Application.Topics;

// операции над топиками
public class TopicsService(IApplicationDbContext dbContext,
    ILogger<TopicsService> logger) : ITopicsService
{
    public Task<Topic> CreateTopicAsync(Topic topicRequestDto)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Topic>> GetTopicsAsync()
    {
        var topics = await dbContext.Topics
            .AsNoTracking() // отключение отслеживания изменений (т.к. это операция чтения)
            .ToListAsync();

        return topics;
    }

    public Task<Topic> GetTopicAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Topic> UpdateTopicAsync(TopicId id, Topic topicRequestDto)
    {
        throw new NotImplementedException();
    }

    public Task DeleteTopicAsync(TopicId id)
    {
        throw new NotImplementedException();
    }
}