using PawRescue.Domain.Enum;

namespace PawRescue.Domain.Dtos.Animal;

public class UpdateAnimalDTO
{
    public int Id { get; set; }

    public int ShelterId { get; set; }

    public string Name { get; set; } = null!;

    public string Species { get; set; } = null!;

    public string Breed { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public int Age { get; set; }

    public int Weight { get; set; }

    public AnimalSize Size { get; set; }

    public string? Description { get; set; }

    public List<string> Documents { get; set; } = null!;

    public List<string> Photos { get; set; } = null!;

    public bool IsHealthy { get; set; }

    public bool IsVaccinated { get; set; }

    public bool IsSterilized { get; set; }

    public AdoptionStatus AdoptionStatus { get; set; }
}
