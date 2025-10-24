using Microsoft.AspNetCore.Identity;
using PawRescue.Domain.Enum;

namespace PawRescue.Domain.Entities.Identity;

public class AppUser : IdentityUser
{
    public string? RefreshToken { get; set; }
    public DateTime RefreshTokenExpiryTime { get; set; }
    public string FullName { get; set; }
    public string? Description { get; set; }
    public DateTime RegistrationDate { get; set; } = DateTime.Now;
    public DateTime? DeletionDate { get; set; }
    public EntityStatus Status { get; set; } = EntityStatus.Active;
}
