using PawRescue.Domain.Enum;

namespace PawRescue.Domain.Dtos.Users;

public class GridUserDTO
{
    public string Id { get; set; }
    public string Email { get; set; }
    public string FullName { get; set; }
    public string? Description { get; set; }
    public string? Photo { get; set; }
    public string PhoneNumber { get; set; }
    public DateTime RegistrationDate { get; set; }
    public EntityStatus Status { get; set; }
}
