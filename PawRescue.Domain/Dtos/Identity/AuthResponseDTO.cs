using PawRescue.Domain.Dtos.Users;

namespace PawRescue.Domain.Dtos.Identity;

public record AuthResponseDto(
        string AccessToken,
        int ExpiresIn,
        string RefreshToken,
        UserDTO User
);
