namespace Application.Dtos;

// объект для возврата информации о теме клиенту
public record TopicResponseDto(
    Guid Id,
    string Title,
    string Summary,
    string TopicType,
    LocationDto Location,
    DateTime? EventStart
);