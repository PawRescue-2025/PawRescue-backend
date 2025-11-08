using PawRescue.Domain.Enum;

namespace PawRescue.Domain.Dtos.Comment;

public class StatusCommentDTO
{
    public int Id { get; set; }
    public EntityStatus Status { get; set; }
}
