using PawRescue.Domain.Entities.Identity;

namespace PawRescue.Domain.Entities;

public partial class Verification
{
    public int Id { get; set; }

    public string Status { get; set; } = null!;

    public string UserId { get; set; } = null!;

    public string Documents { get; set; } = null!;

    public virtual AppUser User { get; set; } = null!;
}
