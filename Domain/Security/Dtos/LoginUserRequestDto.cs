namespace Domain.Security.Dtos;

public record LoginUserRequestDto(
    string Email,
    string Password
);