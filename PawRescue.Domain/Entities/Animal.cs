namespace PawRescue.Domain.Entities;

public partial class Animal
{
    public int Id { get; set; }

    public int ShelterId { get; set; }

    public string Name { get; set; } = null!;

    public string Species { get; set; } = null!;

    public string Breed { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public int Age { get; set; }

    public int Weight { get; set; }

    public string Size { get; set; } = null!;

    public string? Description { get; set; }

    public bool IsHealthy { get; set; }

    public bool IsVaccinated { get; set; }

    public bool IsSterilized { get; set; }

    public string AdoptionStatus { get; set; } = null!;

    public DateTime ArrivalDate { get; set; }

    public virtual Shelter Shelter { get; set; } = null!;
}
