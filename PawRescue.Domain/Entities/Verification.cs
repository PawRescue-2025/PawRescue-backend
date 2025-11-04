using PawRescue.Domain.Entities.Identity;
using PawRescue.Domain.Enum;

namespace PawRescue.Domain.Entities;

public partial class Verification
{
    public int Id { get; set; }

    public VerificationStatus Status { get; set; } = VerificationStatus.NotVerified;

    public string UserId { get; set; } = null!;

    public string Documents { get; set; } = null!;

    public virtual AppUser User { get; set; } = null!;
}
