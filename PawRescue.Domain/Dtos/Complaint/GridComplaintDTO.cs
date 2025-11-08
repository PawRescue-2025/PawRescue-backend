using PawRescue.Domain.Enum;

namespace PawRescue.Domain.Dtos.Complaint;

public class GridComplaintDTO
{
    public int Id { get; set; }

    public string? ComplainantId { get; set; }

    public string? UserId { get; set; }

    public int? PostId { get; set; }

    public int? CommentId { get; set; }

    public string Category { get; set; } = null!;

    public string? Description { get; set; }

    public ComplaintStatus Status { get; set; }

    public DateTime CreationDate { get; set; }
}
