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

    public async Task<List<Topic>> GetTopicsAsync(CancellationToken ct)
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

            return topics;
        }
        catch (System.Exception)
        {
            logger.LogWarning(">> Запрос отменен");
            return new List<Topic>();
        }
    }

    public Task<Topic> GetTopicAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Topic> UpdateTopicAsync(Guid id, Topic topicRequestDto)
    {
        throw new NotImplementedException();
    }

    public Task DeleteTopicAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}