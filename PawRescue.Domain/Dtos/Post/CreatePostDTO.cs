using PawRescue.Domain.Enum;

namespace PawRescue.Domain.Dtos.Post;

public class CreatePostDTO
{
    public string UserId { get; set; } = null!;

    public PostType PostType { get; set; }

    public DateTime? EventDate { get; set; }

    public string Title { get; set; } = null!;

    public string Content { get; set; } = null!;

    public EntityStatus Status { get; set; }

    public string? Location { get; set; }

    public string? ContactPhone { get; set; }

    public string? ContactEmail { get; set; }

    public string? ContactLink { get; set; }

    public List<string> Photos { get; set; } = new();
}
