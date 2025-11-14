namespace PawRescue.Domain.Dtos.Resource;

public class GridResourceDTO
{
    public int Id { get; set; }

    public int ShelterId { get; set; }

    public string Category { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public bool IsPresent { get; set; }
}
