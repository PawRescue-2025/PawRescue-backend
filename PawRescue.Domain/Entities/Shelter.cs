using PawRescue.Domain.Entities.Identity;

namespace PawRescue.Domain.Entities;

public partial class Shelter
{
    public int Id { get; set; }

    public string OwnerId { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Location { get; set; } = null!;

    public string? ContactPhone { get; set; }

    public string? ContactEmail { get; set; }

    public string? ContactLink { get; set; }

    public virtual ICollection<Animal> Animals { get; set; } = new List<Animal>();

    public virtual AppUser Owner { get; set; } = null!;

    public virtual ICollection<Resource> Resources { get; set; } = new List<Resource>();
}
