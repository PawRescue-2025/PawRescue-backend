namespace PawRescue.Domain.Dtos.Shelter;

public class GridShelterDTO
{
    public int Id { get; set; }
    public string OwnerId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Location { get; set; }
    public string ContactPhone { get; set; }
    public string ContactEmail { get; set; }
    public string? ContactLink { get; set; }
}
