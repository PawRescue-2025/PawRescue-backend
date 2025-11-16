namespace PawRescue.Domain.Dtos.Point;

public class GridPointDTO
{
    public int Id { get; set; }

    public string RecipientId { get; set; } = null!;

    public string? ReviewerId { get; set; }

    public int Points { get; set; }

    public string Comment { get; set; } = null!;

    public DateTime ReviewDate { get; set; }
}
