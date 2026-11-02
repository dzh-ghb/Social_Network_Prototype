namespace Application.Topics.Commands.DeleteTopic;

public record DeleteTopicCommand(Guid Id)
    : ICommand<DeleteTopicResult>;

public record DeleteTopicResult(bool IsSuccess);