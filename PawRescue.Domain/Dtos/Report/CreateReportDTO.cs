namespace PawRescue.Domain.Dtos.Report;

public class CreateReportDTO
{
    public int PostId { get; set; }

    public string Text { get; set; } = null!;

    public List<string> Documents { get; set; } = new List<string>();

    public List<string> Photos { get; set; } = new List<string>();
}
