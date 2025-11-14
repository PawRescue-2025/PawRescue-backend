using PawRescue.Domain.Entities.Identity;

namespace PawRescue.Domain.Entities;

public partial class Point
{
    public int Id { get; set; }

    public string RecipientId { get; set; } = null!;

    public string? ReviewerId { get; set; }

    public int Points { get; set; }

    public string Comment { get; set; } = null!;

    public DateTime ReviewDate { get; set; }

    public virtual AppUser Recipient { get; set; } = null!;

    public virtual AppUser? Reviewer { get; set; }
}
