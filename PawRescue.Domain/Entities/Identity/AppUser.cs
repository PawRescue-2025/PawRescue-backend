using Microsoft.AspNetCore.Identity;

namespace PawRescue.Domain.Entities.Identity;

public class AppUser : IdentityUser
{
    public string? RefreshToken { get; set; }
    public DateTime RefreshTokenExpiryTime { get; set; }
}
