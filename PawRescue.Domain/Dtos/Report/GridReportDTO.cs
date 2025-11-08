namespace PawRescue.Domain.Dtos.Report;

public class GridReportDTO
{
    public int Id { get; set; }

    public int PostId { get; set; }

    public string Text { get; set; }

    public List<string> Documents { get; set; } = null!;

    public List<string> Photos { get; set; } = null!;
}
