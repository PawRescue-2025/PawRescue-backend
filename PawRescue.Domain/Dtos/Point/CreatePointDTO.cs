namespace PawRescue.Domain.Dtos.Point;

public class CreatePointDTO
{
    public string RecipientId { get; set; } = null!;

    public string? ReviewerId { get; set; }

    public int Points { get; set; }

    public string Comment { get; set; } = null!;
}
