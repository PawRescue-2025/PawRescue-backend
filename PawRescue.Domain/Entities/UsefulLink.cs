namespace PawRescue.Domain.Entities;

public partial class UsefulLink
{
    public int Id { get; set; }

    public string Type { get; set; } = null!;

    public string Title { get; set; } = null!;

    public string Content { get; set; } = null!;
}
