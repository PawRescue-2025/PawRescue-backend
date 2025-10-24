using System;
using System.Collections.Generic;

namespace PawRescue.Domain.Entities;

public partial class Comment
{
    public int Id { get; set; }

    public string AuthorId { get; set; } = null!;

    public int PostId { get; set; }

    public string Content { get; set; } = null!;

    public string Status { get; set; } = null!;

    public DateTime CreationDate { get; set; }

    public DateTime? DeletionDate { get; set; }

    public virtual AspNetUser Author { get; set; } = null!;

    public virtual ICollection<Complaint> Complaints { get; set; } = new List<Complaint>();

    public virtual Post Post { get; set; } = null!;
}
