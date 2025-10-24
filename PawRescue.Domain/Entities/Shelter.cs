using System;
using System.Collections.Generic;

namespace PawRescue.Domain.Entities;

public partial class Shelter
{
    public int Id { get; set; }

    public string OwnerId { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Location { get; set; } = null!;

    public virtual ICollection<Animal> Animals { get; set; } = new List<Animal>();

    public virtual AspNetUser Owner { get; set; } = null!;

    public virtual ICollection<Resource> Resources { get; set; } = new List<Resource>();
}
