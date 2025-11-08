namespace PawRescue.Domain.Dtos.Comment;

public class CreateCommentDTO
{
    public int PostId { get; set; }
    public string AuthorId { get; set; }
    public string Content { get; set; }
}
