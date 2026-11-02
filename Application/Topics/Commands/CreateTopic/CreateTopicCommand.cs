namespace Application.Topics.Commands.CreateTopic;

public record CreateTopicCommand(CreateTopicRequestDto TopicDto)
    : ICommand<CreateTopicResult>;

public record CreateTopicResult(TopicResponseDto Topic);
