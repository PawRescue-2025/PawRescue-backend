namespace PawRescue.Domain.Entities;

public partial class Report
{
    public int Id { get; set; }

    public int PostId { get; set; }

    public string? Text { get; set; }

    public string Documents { get; set; } = null!;

    public string Photos { get; set; } = null!;

    public DateTime CreationDate { get; set; }

    public virtual Post Post { get; set; } = null!;
}
