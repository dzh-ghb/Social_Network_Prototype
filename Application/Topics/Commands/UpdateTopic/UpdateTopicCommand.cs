namespace Application.Topics.Commands.UpdateTopic;

public record UpdateTopicCommand(Guid Id, UpdateTopicRequestDto TopicDto)
    : ICommand<UpdateTopicResult>;

public record UpdateTopicResult(TopicResponseDto Topic);