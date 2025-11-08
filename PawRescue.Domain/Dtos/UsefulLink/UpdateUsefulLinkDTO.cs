namespace PawRescue.Domain.Dtos.UsefulLink;

public class UpdateUsefulLinkDTO
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Content { get; set; } = null!;
}
