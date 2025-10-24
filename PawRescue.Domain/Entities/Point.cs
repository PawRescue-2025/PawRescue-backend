using System;
using System.Collections.Generic;

namespace PawRescue.Domain.Entities;

public partial class Point
{
    public int Id { get; set; }

    public string RecipientId { get; set; } = null!;

    public string? ReviewerId { get; set; }

    public int Points { get; set; }

    public string Comment { get; set; } = null!;

    public DateTime ReviewDate { get; set; }

    public virtual AspNetUser Recipient { get; set; } = null!;

    public virtual AspNetUser? Reviewer { get; set; }
}
