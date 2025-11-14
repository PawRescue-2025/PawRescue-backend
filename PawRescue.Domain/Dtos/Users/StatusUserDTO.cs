using PawRescue.Domain.Enum;

namespace PawRescue.Domain.Dtos.Users;

public class StatusUserDTO
{
    public string Id { get; set; }
    public EntityStatus Status { get; set; }
}
