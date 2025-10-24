using System;
using System.Collections.Generic;

namespace PawRescue.Domain.Entities;

public partial class Report
{
    public int Id { get; set; }

    public int PostId { get; set; }

    public string? Text { get; set; }

    public DateTime CreationDate { get; set; }

    public virtual Post Post { get; set; } = null!;
}
