using System;
using System.Collections.Generic;

namespace PawRescue.Domain.Entities;

public partial class Verification
{
    public int Id { get; set; }

    public string Status { get; set; } = null!;

    public string UserId { get; set; } = null!;

    public virtual AspNetUser User { get; set; } = null!;
}
