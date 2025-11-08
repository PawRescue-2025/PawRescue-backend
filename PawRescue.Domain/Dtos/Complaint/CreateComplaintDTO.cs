namespace PawRescue.Domain.Dtos.Complaint;

public class CreateComplaintDTO
{
    public string? ComplainantId { get; set; }

    public string? UserId { get; set; }

    public int? PostId { get; set; }

    public int? CommentId { get; set; }

    public string Category { get; set; } = null!;

    public string? Description { get; set; }
}
