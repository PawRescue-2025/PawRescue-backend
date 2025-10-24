namespace PawRescue.Domain.Dtos.Shelter;

public class CreateShelterDTO
{
    public string OwnerId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Location { get; set; }
}
