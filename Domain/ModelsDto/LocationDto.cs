namespace Domain.ModelsDto;

// объект для передачи информации о локации
public record LocationDto(
    string City,
    string Street
);