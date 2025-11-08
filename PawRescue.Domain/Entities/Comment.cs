using PawRescue.Domain.Entities.Identity;
using PawRescue.Domain.Enum;
using System;
using System.Collections.Generic;

namespace PawRescue.Domain.Entities;

public partial class Comment
{
    public int Id { get; set; }

    public string AuthorId { get; set; } = null!;

    public int PostId { get; set; }

    public string Content { get; set; } = null!;

    public EntityStatus Status { get; set; } = EntityStatus.Active;

    public DateTime CreationDate { get; set; }

    public DateTime? DeletionDate { get; set; }

    public virtual AppUser Author { get; set; } = null!;

    public virtual ICollection<Complaint> Complaints { get; set; } = new List<Complaint>();

    public virtual Post Post { get; set; } = null!;
}
