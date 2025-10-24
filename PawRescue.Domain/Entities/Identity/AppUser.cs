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

    public virtual ICollection<Comment> Comments { get; set; }
    public virtual ICollection<Complaint> ComplaintComplainants { get; set; }
    public virtual ICollection<Complaint> ComplaintUsers { get; set; }
    public virtual ICollection<Point> PointRecipients { get; set; }
    public virtual ICollection<Point> PointReviewers { get; set; }
    public virtual ICollection<Post> Posts { get; set; }
    public virtual ICollection<Shelter> Shelters { get; set; }
    public virtual ICollection<Verification> Verifications { get; set; }
}
