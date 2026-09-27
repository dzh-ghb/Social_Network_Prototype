namespace Application.Dtos;

public record CreateTopicRequestDto(
    string Title,
    string Summary,
    string TopicType,
    LocationDto Location,
    DateTime EventStart
);