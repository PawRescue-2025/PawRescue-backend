using PawRescue.Domain.Entities.Identity;
using PawRescue.Domain.Enum;
using System;
using System.Collections.Generic;

namespace PawRescue.Domain.Entities;

public partial class Complaint
{
    public int Id { get; set; }

    public string? ComplainantId { get; set; }

    public string? UserId { get; set; }

    public int? PostId { get; set; }

    public int? CommentId { get; set; }

    public string Category { get; set; } = null!;

    public string? Description { get; set; }

    public ComplaintStatus Status { get; set; }

    public DateTime CreationDate { get; set; }

    public virtual Comment? Comment { get; set; }

    public virtual AppUser? Complainant { get; set; }

    public virtual Post? Post { get; set; }

    public virtual AppUser? User { get; set; }
}
