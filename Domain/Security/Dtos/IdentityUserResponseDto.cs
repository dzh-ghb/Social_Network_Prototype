namespace Domain.Security.Dtos;

public record IdentityUserResponseDto(
    string UserName,
    string Email,
    string JwtToken
);