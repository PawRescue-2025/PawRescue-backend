namespace PawRescue.Domain.Dtos.Identity;

public record RefreshTokenRequestDTO(string AccessToken, string RefreshToken);