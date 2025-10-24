using System;
using System.Collections.Generic;

namespace PawRescue.Domain.Entities;

public partial class Resource
{
    public int Id { get; set; }

    public int ShelterId { get; set; }

    public string Category { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public bool IsPresent { get; set; }

    public virtual Shelter Shelter { get; set; } = null!;
}
