namespace PawRescue.Domain.Dtos.Post;

public class UpdatePostDTO
{
    public int Id { get; set; }

    public DateTime? EventDate { get; set; }

    public string Content { get; set; } = null!;

    public string? ContactPhone { get; set; }

    public string? ContactEmail { get; set; }

    public string? ContactLink { get; set; }

    public string? Location { get; set; }
}
