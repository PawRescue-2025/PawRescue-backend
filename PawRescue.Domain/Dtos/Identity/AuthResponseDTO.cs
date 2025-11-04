using PawRescue.Domain.Dtos.Users;
using PawRescue.Domain.Enum;

namespace PawRescue.Domain.Dtos.Identity;

public record AuthResponseDto(
        string AccessToken,
        int ExpiresIn,
        string RefreshToken,
        UserDTO User,
        VerificationStatus Status
);
