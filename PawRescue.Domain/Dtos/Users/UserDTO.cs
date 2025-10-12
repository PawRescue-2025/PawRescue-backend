namespace PawRescue.Domain.Dtos.Users;

public record UserDTO(
    string UserId,
    string Email,
    IList<string> Roles
);
