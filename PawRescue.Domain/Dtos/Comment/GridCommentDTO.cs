using PawRescue.Domain.Enum;

namespace PawRescue.Domain.Dtos.Comment;

public class GridCommentDTO
{
    public int Id { get; set; }
    public int PostId { get; set; }
    public string AuthorId { get; set; }
    public string Content { get; set; }
    public EntityStatus Status { get; set; }
    public DateTime CreationDate { get; set; }
}
